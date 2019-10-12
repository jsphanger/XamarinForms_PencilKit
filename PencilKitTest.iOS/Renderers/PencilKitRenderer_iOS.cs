using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using PencilKitTest.Controls;
using PencilKitTest.iOS.Renderers;
using PencilKit;
using UIKit;

[assembly: ExportRenderer(typeof(PencilKitView), typeof(PencilKitRenderer_iOS) )]
namespace PencilKitTest.iOS.Renderers
{
    public class PencilKitRenderer_iOS : ViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
		{
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                if(e.NewElement is PencilKitView pkView)
                {
                    var bounds = e.NewElement.Bounds;

                    //Provides the drawable region
                    var pkPencilView = new PKCanvasView();
                    pkPencilView.Frame = new CoreGraphics.CGRect(bounds.X, bounds.Y, bounds.Width, bounds.Height);

                    //PKDrawing - Data Model.  Captures all the beautiful strokes

                    //PKToolPicker - The main tool kit
                    

                    //PKTools - Provides inks
                    pkPencilView.Tool = new PKInkingTool(PKInkType.Pen, UIKit.UIColor.Blue, 40);
                    SetNativeControl(pkPencilView);
                }
            }
		}
    }
}
