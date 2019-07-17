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
using Slipe.Client.Peds;
using Slipe.Client.Events;

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
            Camera.Instance.Fade(Slipe.Shared.Rendering.CameraFade.In);
            Camera.Instance.SetMatrix(new Vector3(2729.7429199219f, -2300.41015625f, 10.981800079346f), new Vector3 (2729.4001464844f, -2306.2919921875f, 10.65811252594f), 0, 70);

            LocalPlayer.Instance.OnDamage += (Ped source, OnDamageEventArgs eventArgs) =>
            {
                if (LocalPlayer.Instance.Team.Name == "Administrative Staff")
                    Event.Cancel();
            };

            LocalPlayer.Instance.OnChoke += (LocalPlayer source, OnChokeEventArgs eventArgs) =>
            {
                Event.Cancel();
            };

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
