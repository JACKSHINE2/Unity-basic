using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Threads : MonoBehaviour {
    Thread thread;
    Thread thread1;
    // Use this for initialization
    void Start () {
        //线程  
        
        
        //相对同时进行各自工作
        //thread = new Thread(Text1);
        //thread1 = new Thread(Text2);
        //thread.Start();
        //thread1.Start();

        //协程  
        //相当于一种计时器
        StartCoroutine(Text3());
        StartCoroutine(Text4());
    }





    /// <summary>
    /// 线程
    /// </summary>
    //线程是系统独立调度和分配的基本单位
    //线程的几个特征：首先线程是有独立的栈来进行工作的，其次在统一进程当中，堆是共享的，线程有三种执行状态：就绪，阻塞，执行，多线程可以并发执行。
    //但在这里我们要注意一下，并发的线程逻辑简单来说是这样的，有A,B两个线程，程序现在A当中执行，再跳回B，再转回A，执行方式是进行了伪并发。
    //我们以上方老王和同时合作进行开发为例，假设老王装箱要进行20次操作

    public void Text1()
    {
        for (int i = 0; i < 5; i++)
        {
            print(i);
        }
    }

    public void Text2()
    {
        for (int i = 10; i > 5; i--)
        {
            print(i);
        }
    }






    /// <summary>
    /// 协程
    /// </summary>
    //不同时进行，是在yiel return 后发生不同进行的
    public IEnumerator Text3()
    {
        print("2s后，显示下一行");
        yield return new WaitForSeconds(2);
        for (int i = 0; i < 5; i++)
        {
            print("2");
        }
    }    


    public IEnumerator Text4()
    {
        print("3s后，显示下一行");
        yield return new WaitForSeconds(2);
        for (int i = 0; i < 5; i++)
        {
            print("3");
        }

    }

    void Update () {
		
	}
}
