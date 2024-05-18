﻿#region License
// Microsoft Public License (Ms-PL)
// 
// This license governs use of the accompanying software. If you use the software, you accept this license. If you do not accept the license, do not use the software.
// 
// 1. Definitions
// 
//   The terms "reproduce," "reproduction," "derivative works," and "distribution" have the same meaning here as under U.S. copyright law.
// 
//   A "contribution" is the original software, or any additions or changes to the software.
// 
//   A "contributor" is any person that distributes its contribution under this license.
// 
//   "Licensed patents" are a contributor's patent claims that read directly on its contribution.
// 
// 2. Grant of Rights
// 
//   (A) Copyright Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free copyright license to reproduce its contribution, prepare derivative works of its contribution, and distribute its contribution or any derivative works that you create.
// 
//   (B) Patent Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free license under its licensed patents to make, have made, use, sell, offer for sale, import, and/or otherwise dispose of its contribution in the software or derivative works of the contribution in the software.
// 
// 3. Conditions and Limitations
// 
//   (A) No Trademark License- This license does not grant you rights to use any contributors' name, logo, or trademarks.
// 
//   (B) If you bring a patent claim against any contributor over patents that you claim are infringed by the software, your patent license from such contributor to the software ends automatically.
// 
//   (C) If you distribute any portion of the software, you must retain all copyright, patent, trademark, and attribution notices that are present in the software.
// 
//   (D) If you distribute any portion of the software in source code form, you may do so only under this license by including a complete copy of this license with your distribution. If you distribute any portion of the software in compiled or object code form, you may only do so under a license that complies with this license.
// 
//   (E ) The software is licensed "as-is." You bear the risk of using it. The contributors give no express warranties, guarantees or conditions. You may have additional consumer rights under your local laws which this license cannot change. To the extent permitted under your local laws, the contributors exclude the implied warranties of merchantability, fitness for a particular purpose and non-infringement.
#endregion

#if NET3x || WINDOWS_PHONE
using System.Diagnostics.CodeAnalysis;

namespace System
{
	/// <summary>
	/// Encapsulates a method that has five parameters and does not return a value.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
	[SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes", Justification = "The number of type parameters is necessary to provide the desired behavior.")]
	public delegate void Action<T1, T2, T3, T4, T5>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

	/// <summary>
	/// Encapsulates a method that has five parameters and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
	/// <return>The return value of the method that this delegate encapsulates.</return>
	[SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes", Justification = "The number of type parameters is necessary to provide the desired behavior.")]
	public delegate TResult Func<T1, T2, T3, T4, T5, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);

	/// <summary>
	/// Encapsulates a method that has six parameters and does not return a value.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
	[SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes", Justification = "The number of type parameters is necessary to provide the desired behavior.")]
	public delegate void Action<T1, T2, T3, T4, T5, T6>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);

	/// <summary>
	/// Encapsulates a method that has six parameters and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
	/// <return>The return value of the method that this delegate encapsulates.</return>
	[SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes", Justification = "The number of type parameters is necessary to provide the desired behavior.")]
	public delegate TResult Func<T1, T2, T3, T4, T5, T6, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);

	/// <summary>
	/// Encapsulates a method that has seven parameters and does not return a value.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
	[SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes", Justification = "The number of type parameters is necessary to provide the desired behavior.")]
	public delegate void Action<T1, T2, T3, T4, T5, T6, T7>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7);

	/// <summary>
	/// Encapsulates a method that has seven parameters and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
	/// <return>The return value of the method that this delegate encapsulates.</return>
	[SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes", Justification = "The number of type parameters is necessary to provide the desired behavior.")]
	public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7);

	/// <summary>
	/// Encapsulates a method that has eight parameters and does not return a value.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
	[SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes", Justification = "The number of type parameters is necessary to provide the desired behavior.")]
	public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8);

	/// <summary>
	/// Encapsulates a method that has eight parameters and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
	/// <return>The return value of the method that this delegate encapsulates.</return>
	[SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes", Justification = "The number of type parameters is necessary to provide the desired behavior.")]
	public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8);

	/// <summary>
	/// Encapsulates a method that has nine parameters and does not return a value.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T9">The type of the ninth parameter of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg9">The ninth parameter of the method that this delegate encapsulates.</param>
	[SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes", Justification = "The number of type parameters is necessary to provide the desired behavior.")]
	public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9);

	/// <summary>
	/// Encapsulates a method that has nine parameters and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T9">The type of the ninth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg9">The ninth parameter of the method that this delegate encapsulates.</param>
	/// <return>The return value of the method that this delegate encapsulates.</return>
	[SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes", Justification = "The number of type parameters is necessary to provide the desired behavior.")]
	public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9);

	/// <summary>
	/// Encapsulates a method that has ten parameters and does not return a value.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T9">The type of the ninth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg9">The ninth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
	[SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes", Justification = "The number of type parameters is necessary to provide the desired behavior.")]
	public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10);

	/// <summary>
	/// Encapsulates a method that has ten parameters and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T9">The type of the ninth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg9">The ninth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
	/// <return>The return value of the method that this delegate encapsulates.</return>
	[SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes", Justification = "The number of type parameters is necessary to provide the desired behavior.")]
	public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10);

	/// <summary>
	/// Encapsulates a method that has eleven parameters and does not return a value.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T9">The type of the ninth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg9">The ninth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
	[SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes", Justification = "The number of type parameters is necessary to provide the desired behavior.")]
	public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11);

	/// <summary>
	/// Encapsulates a method that has eleven parameters and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T9">The type of the ninth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg9">The ninth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
	/// <return>The return value of the method that this delegate encapsulates.</return>
	[SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes", Justification = "The number of type parameters is necessary to provide the desired behavior.")]
	public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11);

	/// <summary>
	/// Encapsulates a method that has twelve parameters and does not return a value.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T9">The type of the ninth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg9">The ninth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
	[SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes", Justification = "The number of type parameters is necessary to provide the desired behavior.")]
	public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12);

	/// <summary>
	/// Encapsulates a method that has twelve parameters and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T9">The type of the ninth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg9">The ninth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
	/// <return>The return value of the method that this delegate encapsulates.</return>
	[SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes", Justification = "The number of type parameters is necessary to provide the desired behavior.")]
	public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12);

	/// <summary>
	/// Encapsulates a method that has thirteen parameters and does not return a value.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T9">The type of the ninth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg9">The ninth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg13">The thirteenth parameter of the method that this delegate encapsulates.</param>
	[SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes", Justification = "The number of type parameters is necessary to provide the desired behavior.")]
	public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13);

	/// <summary>
	/// Encapsulates a method that has thirteen parameters and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T9">The type of the ninth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg9">The ninth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg13">The thirteenth parameter of the method that this delegate encapsulates.</param>
	/// <return>The return value of the method that this delegate encapsulates.</return>
	[SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes", Justification = "The number of type parameters is necessary to provide the desired behavior.")]
	public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13);

	/// <summary>
	/// Encapsulates a method that has fourteen parameters and does not return a value.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T9">The type of the ninth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T14">The type of the fourteenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg9">The ninth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg13">The thirteenth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg14">The fourteenth parameter of the method that this delegate encapsulates.</param>
	[SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes", Justification = "The number of type parameters is necessary to provide the desired behavior.")]
	public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14);

	/// <summary>
	/// Encapsulates a method that has fourteen parameters and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T9">The type of the ninth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T14">The type of the fourteenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg9">The ninth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg13">The thirteenth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg14">The fourteenth parameter of the method that this delegate encapsulates.</param>
	/// <return>The return value of the method that this delegate encapsulates.</return>
	[SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes", Justification = "The number of type parameters is necessary to provide the desired behavior.")]
	public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14);

	/// <summary>
	/// Encapsulates a method that has fifteen parameters and does not return a value.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T9">The type of the ninth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T14">The type of the fourteenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T15">The type of the fifteenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg9">The ninth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg13">The thirteenth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg14">The fourteenth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg15">The fifteenth parameter of the method that this delegate encapsulates.</param>
	[SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes", Justification = "The number of type parameters is necessary to provide the desired behavior.")]
	public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15);

	/// <summary>
	/// Encapsulates a method that has fifteen parameters and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T9">The type of the ninth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T14">The type of the fourteenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T15">The type of the fifteenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg9">The ninth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg13">The thirteenth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg14">The fourteenth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg15">The fifteenth parameter of the method that this delegate encapsulates.</param>
	/// <return>The return value of the method that this delegate encapsulates.</return>
	[SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes", Justification = "The number of type parameters is necessary to provide the desired behavior.")]
	public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15);

	/// <summary>
	/// Encapsulates a method that has sixteen parameters and does not return a value.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T9">The type of the ninth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T14">The type of the fourteenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T15">The type of the fifteenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T16">The type of the sixteenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg9">The ninth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg13">The thirteenth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg14">The fourteenth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg15">The fifteenth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg16">The sixteenth parameter of the method that this delegate encapsulates.</param>
	[SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes", Justification = "The number of type parameters is necessary to provide the desired behavior.")]
	public delegate void Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16);

	/// <summary>
	/// Encapsulates a method that has sixteen parameters and returns a value of the type specified by the <typeparamref name="TResult" /> parameter.
	/// </summary>
	/// <typeparam name="T1">The type of the first parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T2">The type of the second parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T3">The type of the third parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T4">The type of the fourth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T5">The type of the fifth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T6">The type of the sixth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T7">The type of the seventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T8">The type of the eighth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T9">The type of the ninth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T10">The type of the tenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T11">The type of the eleventh parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T12">The type of the twelfth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T13">The type of the thirteenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T14">The type of the fourteenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T15">The type of the fifteenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="T16">The type of the sixteenth parameter of the method that this delegate encapsulates.</typeparam>
	/// <typeparam name="TResult">The type of the return value of the method that this delegate encapsulates.</typeparam>
	/// <param name="arg1">The first parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg2">The second parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg3">The third parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg4">The fourth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg5">The fifth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg6">The sixth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg7">The seventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg8">The eighth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg9">The ninth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg10">The tenth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg11">The eleventh parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg12">The twelfth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg13">The thirteenth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg14">The fourteenth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg15">The fifteenth parameter of the method that this delegate encapsulates.</param>
	/// <param name="arg16">The sixteenth parameter of the method that this delegate encapsulates.</param>
	/// <return>The return value of the method that this delegate encapsulates.</return>
	[SuppressMessage("Microsoft.Design", "CA1005:AvoidExcessiveParametersOnGenericTypes", Justification = "The number of type parameters is necessary to provide the desired behavior.")]
	public delegate TResult Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16);

}
#endif
