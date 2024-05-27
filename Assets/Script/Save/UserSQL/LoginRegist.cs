using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class LoginRegist : MonoBehaviour
{
    public bool login_success = false;
    public bool register_success = false;

    public Text logintext;
 
    public InputField userNameInput;
    public InputField passwordInput;
 
    private string username;
    private string password;
    private string role = "普通玩家";
    private void Update()
    {
        username = userNameInput.text;
        //Debug.Log(username);
 
        password = passwordInput.text;
        //Debug.Log(password);
    }
    //点击登录按钮
    public void Click_login(string username, string password)
    {
        string sqlSer = "server = localhost;port = 3306;database = gamedata;user = root;password =12345678;";
        //这里数据库名（database）和密码（password）写自己定义的（这里只是举例），后面的也是
        
        MySqlConnection conn = new MySqlConnection(sqlSer);
        try
        {
            conn.Open();
            Debug.Log("------连接成功------");
 
            string sqlQuary = "select * from usertable where gameName =@paral1 and password = @paral2";
            MySqlCommand comd = new MySqlCommand(sqlQuary, conn);
            comd.Parameters.AddWithValue("paral1", username);
            comd.Parameters.AddWithValue("paral2", password);
 
            MySqlDataReader reader = comd.ExecuteReader();
            if (reader.Read())
            {
                logintext.text=("------用户存在，登录成功！------");
                //进行登入成功后的操作，例如进入新场景。。。
                saveSystem.gameName=username;
                this.gameObject.SetActive(false);
                login_success = true;
            }
            else
            {
                logintext.text=("------用户不存在，请注册。或请检查用户名和密码！------");
                login_success = false;
            }
        }
        catch (System.Exception e)
        {
 
            Debug.Log(e.Message);
        }
        finally
        {
            conn.Close();
        }
    }
    public void OnClick_login()
    {
        Click_login(username, password);
    }
 
    //点击注册按钮时
    public void Click_register(string username, string password)
    {
        string sqlSer = "server = localhost;port = 3306;database = gamedata;user = root;password =12345678;charset = utf8";
 
        MySqlConnection conn = new MySqlConnection(sqlSer);
        try
        {
            conn.Open();
            Debug.Log("-----连接成功！------");
 
            string sqlQuary = "select * from usertable where gameName =@paral1 and password = @paral2";
            MySqlCommand comd = new MySqlCommand(sqlQuary, conn);
            comd.Parameters.AddWithValue("paral1", username);
            comd.Parameters.AddWithValue("paral2", password);
 
            MySqlDataReader reader = comd.ExecuteReader();
            if (reader.Read())
            {
                logintext.text=("-----用户名已存在，请重新输入！------");
                Debug.Log(reader.GetString(2));
                register_success = false;
            }
            else
            {
                Insert_User(username, password);
                logintext.text=("------注册成功，请进行登入------");
                register_success = true;
            }
        }
        catch (System.Exception e)
        {
 
            Debug.Log(e.Message);
        }
        finally
        {
            conn.Close();
        }
    }
    //插入用户
    private void Insert_User(string username, string password)
    {
        string sqlSer = "server = localhost;port = 3306;database = gamedata;user = root;password =12345678;charset = utf8";
  
        MySqlConnection conn = new MySqlConnection(sqlSer);
 
        try
        {
            conn.Open();
            string sqlInsert = "insert into usertable(gameName,password,role) values('" + username + "','" + password +"','"+role+ "')";
            MySqlCommand comd2 = new MySqlCommand(sqlInsert, conn);
            int resule = comd2.ExecuteNonQuery();
        }
        catch (System.Exception e)
        {
 
            Debug.Log(e.Message);
        }
        finally
        {
            conn.Close();
        }
    }
    public void OnClick_register()
    {
        Click_register(username, password);
    }
}
