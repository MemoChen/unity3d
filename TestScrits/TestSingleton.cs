///
///很多时候我们需要A脚本调用B脚本里面的属性什么的，
///这个时候我们可以在这个需要被调用属性脚本里面写一个单例模式。
///可项目大了需要被调用的脚本也就会很多，这个时候我们要是还像
///以前那样每个需要被调用的脚本里面就写一个单例模式，那样就太麻烦了。
///所以这里我们可以封装下这个单例模式。
///

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestSingleton <T> where T :new() {

    protected static T sInstance = default(T);
  

    public static T GetInstance()
    {
       if(sInstance==null)
        {
            sInstance = new T();
        }
        return sInstance;
    }
}

/// <summary>
/// 需要调用单例的地方写成：
/// </summary>
public class EventCenter : TestSingleton<EventCenter>
{

}
