using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using TrenteArpents.Controls;
using TrenteArpents.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ListViewWithoutScroll), typeof(ListViewWithoutScrollRenderer))]
namespace TrenteArpents.iOS.Renderers
{
    public class ListViewWithoutScrollRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                Control.ScrollEnabled = false;
            }
        }
    }
}