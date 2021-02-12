using Silk.NET.OpenGL;
using System.Drawing;
using System.Numerics;
using TrippyGL;

namespace TrippyTest
{
	internal class TrippyTest: TestBase
	{
		private TextureBatcher _batch;
		private Texture2D _white;

		protected override void OnLoad()
		{
			graphicsDevice.DepthState = DepthState.None;
			graphicsDevice.FaceCullingEnabled = false;
			graphicsDevice.BlendState = BlendState.Opaque;
			graphicsDevice.ClearColor = new Vector4(0, 0, 0, 1);

			SimpleShaderProgram shaderProgram = SimpleShaderProgram.Create<VertexColorTexture>(graphicsDevice, 0, 0, true);
			_batch = new TextureBatcher(graphicsDevice);
			_batch.SetShaderProgram(shaderProgram);

			_white = new Texture2D(graphicsDevice, 1, 1);
			_white.SetTextureFilters(TextureMinFilter.Nearest, TextureMagFilter.Nearest);
			var colors = new Color4b[1];
			colors[0] = Color4b.White;
			_white.SetData<Color4b>(colors);
		}


		protected override void OnRender(double dt)
		{
			graphicsDevice.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.DepthBufferBit);
			//			_desktop.Render();

			_batch.Begin();

			_batch.Draw(_white, new Vector2(0, 0), null, Color4b.Red, 100, 0);

			_batch.End();

			Window.SwapBuffers();
		}

		protected override void OnResized(Size size)
		{
		}

		protected override void OnUnload()
		{
		}
	}
}
