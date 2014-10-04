using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Screen
{
	class MyApplication
    {
        [STAThread]
        public static void Main()
        {
			using (var game = new GameWindow())
            {
				Camera cam = new Camera();
				Vector2 lastMousePos = new Vector2();
//			 	string filename = "../../src/img/tarmac.bmp";
				
                game.Load += (sender, e) =>
                {
					
					// setup settings, load textures, sounds
					
					/*
					using (var bitmap = new Bitmap(filename)) {
						//					    var width = bitmap.Width;
						//					    var height = bitmap.Height;
						var textureId = GL.GenTexture();
						GL.BindTexture(TextureTarget.Texture2D, textureId);
						var bitmapData = bitmap.LockBits(
							new Rectangle(0, 0, bitmap.Width, bitmap.Height),
							System.Drawing.Imaging.ImageLockMode.ReadOnly,
							System.Drawing.Imaging.PixelFormat.Format32bppArgb);
						try
						{
							GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba,
							              bitmap.Width, bitmap.Height, 0, PixelFormat.Bgra, PixelType.UnsignedByte,
							              bitmapData.Scan0);
						}
						finally
						{
							bitmap.UnlockBits(bitmapData);
						}
						GL.TexParameter(TextureTarget.Texture2D,
						                TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
						GL.TexParameter(TextureTarget.Texture2D,
						                TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
					}
					*/
					
					/*
					Bitmap image1 = (Bitmap) Image.FromFile(@filename, true);
					
					TextureBrush texture = new TextureBrush(image1);
					texture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
					Graphics formGraphics = this.CreateGraphics();
					formGraphics.FillEllipse(texture, new RectangleF(90.0f, 110.0f, 100, 100));
					formGraphics.Dispose();
					*/
					
					game.Title = "Render";
					game.VSync = VSyncMode.On;
					
					/*
					game.Width = 1024;
					game.Height = 768;
					*/
					
					GL.ClearColor(Color.CornflowerBlue);
					
					Console.WriteLine(game.Width + " x " + game.Height);
                };
 
                game.Resize += (sender, e) =>
                {
					GL.Viewport(0, 0, game.Width, game.Height);
					
					/*** Not sure if this block is needed ***
					
					Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, game.Width / (float)game.Height, 1.0f, 64.0f);
					Matrix4 projection =  cam.GetViewMatrix() * Matrix4.CreatePerspectiveFieldOfView(1.3f, game.ClientSize.Width / (float)game.ClientSize.Height, 1.0f, 64.0f);
					GL.MatrixMode(MatrixMode.Projection);
					GL.LoadMatrix(ref projection);
					****/
                };
				
				game.FocusedChanged += (sender, e) =>
				{
				};
				
				game.MouseMove += (sender, e) =>
				{
					Console.WriteLine(OpenTK.Input.Mouse.GetState().X + " " + OpenTK.Input.Mouse.GetState().Y);
				};
 
                game.UpdateFrame += (sender, e) =>
                {
					if(game.Focused)
					{
						game.CursorVisible = false;
					    Vector2 delta = lastMousePos - new Vector2(OpenTK.Input.Mouse.GetState().X, OpenTK.Input.Mouse.GetState().Y);
					    cam.AddRotation(delta.X, delta.Y);
						OpenTK.Input.Mouse.SetPosition(game.Bounds.Left + game.Bounds.Width / 2, game.Bounds.Top + game.Bounds.Height / 2);
						lastMousePos = new Vector2(OpenTK.Input.Mouse.GetState().X, OpenTK.Input.Mouse.GetState().Y);
					}
					
					Matrix4 projection =  cam.GetViewMatrix() * Matrix4.CreatePerspectiveFieldOfView(1.3f, game.ClientSize.Width / (float)game.ClientSize.Height, 1.0f, 64.0f);
					GL.MatrixMode(MatrixMode.Projection);
					GL.LoadMatrix(ref projection);
                };
				
                game.RenderFrame += (sender, e) =>
                {
                    GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
					
					Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
					GL.MatrixMode(MatrixMode.Modelview);
					GL.LoadMatrix(ref modelview);
					
					GL.Begin(PrimitiveType.Triangles);

					// x y z

					for(var tz = 0; tz < 10; tz++) {
						for(var tx = 0; tx < 10; tx++) {
							var tzpitch = tz + 2;
							var txpitch = tx + 2;
							
							GL.Vertex3(1.0f, -1.0f, tzpitch);
							GL.Vertex3(-1.0f, -1.0f, tzpitch);
							GL.Vertex3(1.0f, -1.0f, tzpitch + 2);

							/*
							GL.Vertex3(1.0f, -1.0f, 3.0f + tzpitch);
							GL.Vertex3(-1.0f, -1.0f, 3.0f + tzpitch);
							GL.Vertex3(1.0f, -1.0f, 5.0f + tzpitch);

							GL.Vertex3(1.0f, -1.0f, 5.0f + tzpitch);
							GL.Vertex3(-1.0f, -1.0f, 5.0f + tzpitch);
							GL.Vertex3(-1.0f, -1.0f, 3.0f + tzpitch);
							*/

//							Console.WriteLine("tx=" + tx + " tz=" + tz + " tzpitch=" + tzpitch);
						}
					}


                    GL.End();
					
					game.SwapBuffers();
                };
				
				game.KeyDown += (sender, e) =>
				{
					if(game.Keyboard[Key.Escape])
					{
						game.Exit();
					}
					if(game.Keyboard[Key.W])
					{
						cam.Move(0f, 0.1f, 0f);
					}
					if(game.Keyboard[Key.S])
					{
						cam.Move(0f, -0.1f, 0f);
					}
					if(game.Keyboard[Key.A])
					{
						cam.Move(-0.1f, 0f, 0f);
					}
					if(game.Keyboard[Key.D])
					{
						cam.Move(0.1f, 0f, 0f);
					}
					/*
					if(game.Keyboard[Key.Q])
					{
						cam.Move(0f, 0f, -0.1f);
					}
					if(game.Keyboard[Key.E])
					{
						cam.Move(0f, 0f, 0.1f);
					}
					
					if(game.Keyboard[Key.KeypadMinus])
					{
					    cam.AddRotation(0.5f, 0);
					}
					if(game.Keyboard[Key.KeypadPlus])
					{
					    cam.AddRotation(-0.5f, 0);
					}
					*/
					Console.WriteLine(" pos=" + cam.Position + " ori=" + cam.Orientation);
				};
				
                game.Run(60.0);
            }
        }
    }
}