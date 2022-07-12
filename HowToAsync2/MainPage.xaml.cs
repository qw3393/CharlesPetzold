using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;

// 빈 페이지 항목 템플릿에 대한 설명은 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x412에 나와 있습니다.

namespace HowToAsync2
{
    /// <summary>
    /// 자체적으로 사용하거나 프레임 내에서 탐색할 수 있는 빈 페이지입니다.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        async void OnButtonClick(object sender, RoutedEventArgs args)
        {
            MessageDialog msgdlg = new MessageDialog("Choose a color", "How To Async #2");
            msgdlg.Commands.Add(new UICommand("Red", null, Colors.Red));
            msgdlg.Commands.Add(new UICommand("Green", null, Colors.Green));
            msgdlg.Commands.Add(new UICommand("Blue", null, Colors.Blue));

            IUICommand command = await msgdlg.ShowAsync();
            Color clr = (Color)command.Id;
            contentGrid.Background = new SolidColorBrush(clr);

            // Show the MessageDialog with a Completed handler
            //IAsyncOperation<IUICommand> asyncOp = msgdlg.ShowAsync();
            //asyncOp.Completed = (asyncInfo, asyncStatus) =>
            //{
            //    // Get the Color value
            //    IUICommand command = asyncInfo.GetResults();
            //    Color clr = (Color)command.Id;

            //    // Use a Dispatcher to run in the UI thread
            //    IAsyncAction asyncAction = this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            //                                                        () =>
            //                                                        {
            //                                                                // Set the background brush
            //                                                                contentGrid.Background = new SolidColorBrush(clr);
            //                                                        });
            //};
        }
    }
}
