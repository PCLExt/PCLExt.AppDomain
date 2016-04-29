﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace PCLExt.AppDomain
{
    /// <summary>
    /// 
    /// </summary>
    public static class AppDomain
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Assembly GetAssembly(Type type)
        {
#if COMMON
            return System.Reflection.Assembly.GetAssembly(type);
#endif

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Assembly[] GetAssemblies()
        {
#if COMMON
            return System.AppDomain.CurrentDomain.GetAssemblies();
#endif

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assemblyData"></param>
        /// <returns></returns>
        public static Assembly LoadAssembly(byte[] assemblyData)
        {
#if COMMON
            return System.Reflection.Assembly.Load(assemblyData);
#endif

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="className"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static Type GetTypeFromNameAndInterface<T>(string className, Assembly assembly)
        {
            foreach (var typeInfo in new List<TypeInfo>(assembly.DefinedTypes))
                if (typeInfo.Name == className)
                    foreach (var type in new List<Type>(typeInfo.ImplementedInterfaces))
                        if (type == typeof (T))
                            return typeInfo.AsType();

            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="className"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static Type GetTypeFromNameAndAbstract<T>(string className, Assembly assembly)
        {
            foreach (var typeInfo in new List<TypeInfo>(assembly.DefinedTypes))
                if (typeInfo.Name == className)
                    if (typeInfo.IsSubclassOf(typeof (T)))
                        return typeInfo.AsType();

            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="className"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static Type GetTypeFromName(string className, Assembly assembly)
        {
            foreach (var typeInfo in new List<TypeInfo>(assembly.DefinedTypes))
                if (typeInfo.Name == className)
                    return typeInfo.AsType();

            return null;
        }
    }
}