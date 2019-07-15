using Slipe.Client.Elements;
using Slipe.Client.IO;
using Slipe.Client.Gui;
using Slipe.Shared.Elements;
using Slipe.Client.Peds;
using Slipe.Client.Peds.Events;
using System.Numerics;
using Slipe.Client.Gui.Events;
using Slipe.Shared.Rpc;
using Slipe.Client.Rpc;
using Slipe.Client;

namespace ClientSide
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }

        public Program()
        {
            Window Login = new Window(new Vector2(0.375f, 0.375f), new Vector2(0.25f, 0.25f), "Login", true);
            Label lUser = new Label(new Vector2(0.0825f, 0.2f), new Vector2(0.25f, 0.25f), "Username", true, Login);
            Label lPW = new Label(new Vector2(0.0825f, 0.5f), new Vector2(0.25f, 0.25f), "Password", true, Login);
            Edit Username = new Edit(new Vector2(0.415f, 0.2f), new Vector2(0.5f, 0.15f), "", true, Login);
            Edit PW = new Edit(new Vector2(0.415f, 0.5f), new Vector2(0.5f, 0.15f), "", true, Login);
            PW.Masked = true;
            PW.MaxLength = 50;
            Username.MaxLength = 50;
            Button sLogin = new Button(new Vector2(0.415f, 0.7f), new Vector2(0.25f, 0.2f), "Login", true, Login);
            Cursor.SetVisible(true);
            Login.Visible = true;
            
           
            
            
            sLogin.OnMouseDown += (GuiElement source, OnMouseDownEventArgs eventArgs) =>
                {
                    ChatBox.WriteLine("pressed login", Slipe.Shared.Utilities.Color.Red);
                    RpcManager.Instance.TriggerRPC("xoaLogin", new LoginRpc(Username.Content, PW.Content));
                    Login.Destroy();
                    Cursor.SetVisible(false);
                };
           
        }

    }
    public class LoginRpc : IRpc
    {
        // the fields to transmit
        public string username;
        public string password;

        // the constructor which sets the fields
        public LoginRpc(string name, string pw)
        {
            this.username = name;
            this.password = pw;
        }
    }
}
