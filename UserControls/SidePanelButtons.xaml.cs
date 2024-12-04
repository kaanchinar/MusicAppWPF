using System.Windows;
using System.Windows.Controls;
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

        public SidePanelButtons()
        {
            InitializeComponent();
        }
    }
}