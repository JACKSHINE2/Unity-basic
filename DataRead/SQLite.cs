using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.IO;

public class SQLite : MonoBehaviour {

    //数据库的链接对象
    SqliteConnection sql;
    string path = "SQLTest.db";
    //读取对象
    SqliteDataReader reader;
    SqliteCommand command;
    //1.将mono.data.dll  system.data   sqlite3.dll放入Plugins文件夹当中
    //2.路径需要加"URI=file"  "Data Source="
    //3.链接数据库  并打开
    //4.执行sql语句
    //5。发布移动端时需要在playersettings当中修改.net2.0subset为.net2.0
    //6.string类型的数据在写入数据当中除了""号之外要加''
    public void Start()
    {
        path = "URI=file:" + Application.streamingAssetsPath + "/" + path;
        sql = new SqliteConnection(path);
        //打开数据库  流
        sql.Open();
        //声明数据库语句对象
        command = sql.CreateCommand();
        //command.CommandText = "Insert Into Student (ID,Name) values (129,'Jack')";
        command.CommandText = "DELETE FROM Student WHERE ID = 87";

        //执行SQL语句 
        command.ExecuteNonQuery();
        command.Dispose();
        sql.Close();


    }
}
