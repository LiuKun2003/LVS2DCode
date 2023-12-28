using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace LK.Utilities
{
    /// <summary>
    /// 用于防止环出现的路径锁
    /// </summary>
    /// <typeparam name="T">此锁中的节点类型</typeparam>
    public class PathLock<T>
    {

        #region Public or protected fields and properties
        /// <summary>
        /// 此路径锁中已被锁定的节点数
        /// </summary>
        public int LockedNodeCount => m_Path.Count;

        /// <summary>
        /// 此路径锁使用的比较器
        /// </summary>
        public IEqualityComparer<T> Comparer => m_Path.Comparer;
        #endregion

        #region Private fields and properties
        private HashSet<T> m_Path;
        #endregion

        #region Public or protected methods
        public PathLock()
        {
            m_Path = new HashSet<T>();
        }

        public PathLock(IEqualityComparer<T> comparer)
        {
            m_Path = new HashSet<T>(comparer);
        }

        /// <summary>
        /// 在此路径中锁定给定的节点。
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public void Lock(T node)
        {
            if(m_Path.Contains(node))
            {
                throw new ArgumentException($"Try to lock the {nameof(node)}, but the {nameof(node)} is already locked.");
            }
            m_Path.Add(node);
        }

        /// <summary>
        /// 在此路径中尝试锁定给定的节点，如果此节点没被锁定，则会将节点锁定并返回 true；反之，则直接返回 false。
        /// </summary>
        public bool TryLock(T node)
        {
            if(m_Path.Contains(node))
            {
                return false;
            }
            else
            {
                m_Path.Add(node);
                return true;
            }
        }

        /// <summary>
        /// 在此路径中释放给的节点。
        /// </summary>
        /// <param name="node"></param>
        public void Release(T node)
        {
            if(!m_Path.Contains(node))
            {
                throw new ArgumentException($"Try to release the {nameof(node)}, but the {nameof(node)} is not locked");
            }
        }

        /// <summary>
        /// 在此路径中尝试释放给定的节点，如果此节点已被锁定，则会将节点释放并返回 true；反之，则直接返回 false。
        /// </summary>
        public bool TryRelease(T node)
        {
            if(m_Path.Contains(node))
            {
                m_Path.Remove(node);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 释放此路径中所有节点。
        /// </summary>
        public void ReleaseAll() => m_Path.Clear();

        /// <summary>
        /// 若一个节点没有在此路径中被锁定，则返回 true。
        /// </summary>
        public bool CanLock(T node) => !m_Path.Contains(node);
        
        /// <summary>
        /// 调整此路径锁的大小。
        /// </summary>
        public void TrimExcess() => m_Path.TrimExcess();
        #endregion

    }
}
