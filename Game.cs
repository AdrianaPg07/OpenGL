using System;
using System.Windows;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;


namespace Practico01
{
    class Game
    {
        private GameWindow window;
        public Game(GameWindow window)
        {
            this.window = window;
            Start();

        }

        void Start()
        {
            window.Load += loaded;
            window.Resize += rezise;
            window.RenderFrame += renderF;

            window.Run(1.0 / 60.0);
        }

        void loaded(object o, EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            GL.Enable(EnableCap.DepthTest);





        }

        void rezise(object o, EventArgs e)
        {
            int Width = window.Width;
            int Height = window.Height;

            float aspectRatio = 1.0f;

            if ((Width > 0) && (Height > 0))
            {
                if (Width > Height)
                {
                    aspectRatio = Width / Height;
                }
                else if (Width < Height)
                {
                    aspectRatio = Height / Width;
                }
            }


            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            Matrix4 matrix = Matrix4.Perspective(45.0f, aspectRatio, 1.0f, 100.0f);
            GL.LoadMatrix(ref matrix);
            //GL.Ortho(0.0, 50.0, 0.0, 50.0, -1.0, 1.0);
            GL.MatrixMode(MatrixMode.Modelview);


        }


        void renderF(object o, EventArgs e)
        {

            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.Translate(0.0, 0.0, -30.0);
            GL.Rotate(40.0, 1, 1, 0);

            silla3d(5.0, 5.0, 0.0, 5.0, 0.0);
            

            window.SwapBuffers();

        }

        void silla3d(double dx, double dy, double cx, double cy, double cz)
        {

            tabla(dx, dy, cx, cy, cz);

            double width = dx * 0.1;
            double center = dx / 2;

            pata(width, dy, cx - center + width, cy, cz - center + width);//pata1
            pata(width, dy, cx - center + width, cy, cz + center - width);//pata2
            pata(width, dy, cx + center - width, cy, cz + center - width);//pata3
            pata(width, dy, cx + center - width, cy, cz - center + width);//pata4

        }

        void tabla(double dx, double dy, double cx, double cy, double cz)
        {

            double width = dx / 2;
            double height = dy / 2;

            GL.Begin(BeginMode.Polygon);

            GL.Vertex3(cx - width, cy + height, cz - width);
            GL.Vertex3(cx + width, cy + height, cz - width);
            GL.Vertex3(cx + width, cy + height, cz + width);
            GL.Vertex3(cx - width, cy + height, cz + width);

            GL.End();

        }

        void pata(double dx, double dy, double cx, double cy, double cz)
        {

            double height = dy / 2;

            GL.Begin(BeginMode.Polygon);//plano1 frontal

            GL.Vertex3(cx - dx, cy + height, cz + dx);
            GL.Vertex3(cx + dx, cy + height, cz + dx);
            GL.Vertex3(cx + dx, cy - height, cz + dx);
            GL.Vertex3(cx - dx, cy - height, cz + dx);

            GL.End();

            GL.Begin(BeginMode.Polygon);//plano2 atras

            GL.Vertex3(cx - dx, cy + height, cz - dx);
            GL.Vertex3(cx + dx, cy + height, cz - dx);
            GL.Vertex3(cx + dx, cy - height, cz - dx);
            GL.Vertex3(cx - dx, cy - height, cz - dx);

            GL.End();


            GL.Begin(BeginMode.Polygon);//plano1 izquierda

            GL.Vertex3(cx - dx, cy + height, cz + dx);
            GL.Vertex3(cx - dx, cy + height, cz - dx);
            GL.Vertex3(cx - dx, cy - height, cz + dx);
            GL.Vertex3(cx - dx, cy - height, cz - dx);

            GL.End();

            GL.Begin(BeginMode.Polygon);//plano2 derecha

            GL.Vertex3(cx + dx, cy + height, cz + dx);
            GL.Vertex3(cx + dx, cy + height, cz - dx);
            GL.Vertex3(cx + dx, cy - height, cz + dx);
            GL.Vertex3(cx + dx, cy - height, cz - dx);

            GL.End();


        }






    }



}
