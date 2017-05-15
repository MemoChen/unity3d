using System;
using UnityEngine;

public class TestLambda :MonoBehaviour  {


    private void Start()
    {
        TestMain();
    }
    public static void TestMain()
    {
        //匿名方法
        //每一个委托的定义都必须通过一个能匹配的方法来完成
        //然而有时候，用来初始化委托用的方法并不一定就是我们想用的，也许仅仅是为了初始化委托


        //委托
        Func<int, int, int> info = delegate (int a, int b)
            {
                return a + b;
            };
        Debug.LogError(info(11,89));

        //Lambda表达式
        //简化版的匿名方法，参数不需要生命类型，括号里是参数列表，返回值用return返回即可
        Func<int, int, int> info2 = (a2, b2) =>
          {
              return a2 + b2;
          };
        Debug.LogError(info2(11, 89));

        //如果只有一个参数的时候则不需要使用（）把参数括起来
        //如果方法只有一行代码，即只有一个；的时候，也可以不用{}括起来
        //如果这个方法有返回值，不适用return就可以返回方法体的值
        //如果这个方法没有返回值，那么方法体便不会将值返回给匿名函数
        Func<string, int> info3 = name => 18;
        Debug.LogError(info3("pingge"));
    }
}
