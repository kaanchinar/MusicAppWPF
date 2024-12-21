using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FontAwesome.Sharp;

namespace MusicAppWPF.UserControls
{
    public partial class SidePanelButtons : UserControl
    {
        public static readonly DependencyProperty ButtonTextProperty =
            DependencyProperty.Register("ButtonText", typeof(string), typeof(SidePanelButtons), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty ButtonIconProperty =
            DependencyProperty.Register("ButtonIcon", typeof(IconChar), typeof(SidePanelButtons), new PropertyMetadata(IconChar.None));

        public string ButtonText
        {
            get { return (string)GetValue(ButtonTextProperty); }
            set { SetValue(ButtonTextProperty, value); }
        }

        public IconChar ButtonIcon
        {
            get { return (IconChar)GetValue(ButtonIconProperty); }
            set { SetValue(ButtonIconProperty, value); }
        }
        public static readonly DependencyProperty ButtonCommandProperty =
    DependencyProperty.Register("ButtonCommand", typeof(ICommand), typeof(SidePanelButtons), new PropertyMetadata(null));
        public ICommand ButtonCommand
        {
            get { return (ICommand)GetValue(ButtonCommandProperty); }
            set { SetValue(ButtonCommandProperty, value); }
        }

        public SidePanelButtons()
        {
            InitializeComponent();
        }
    }
}