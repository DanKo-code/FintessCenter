   M S B A M L   `   `   `  ����H  DFitnessCenter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Fclr-namespace:FitnessCenter.Views.Windows.Main.UserControls.Abonements8FitnessCenter.Views.Windows.Main.UserControls.Abonements  5      A%clr-namespace:FitnessCenter.ViewModelFitnessCenter.ViewModel  5
      M    GFitnessCenter.Views.Windows.Main.UserControls.Abonements.AbonementsCore   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      XlocalFclr-namespace:FitnessCenter.Views.Windows.Main.UserControls.Abonements     5      4vm%clr-namespace:FitnessCenter.ViewModel     5
      .��5      �   � DataContext  5   
   1  +FitnessCenter.ViewModel.AbonementsViewModel  5       � RowDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      �� 5      $
��0.3* �6   .+�5   
   �� $��Center=�6   $��Center=�60    �� Orientation$ 
Horizontal=�6M   $��0��6f   .+�5      �� $��	0 0 100 0q�6   $ 
Horizontal=�6,   .+�5       �� $��Вид��6   �� 5!      $	��100��6   5"      �� 5$      $ 
Horizontal=�6   .+�5%      �� $��
Поиск��6   �� 5&      $	��100��6   5'      �� 5)      $��R��6>   $��40��6J   $��40��6U   $��	100 0 0 0q�6a   ��6   �� *ReloudAbonementsList+6a   5+      �� 5.   
   $��1��6   
������ $��Center=�5/      $��Center=�50      ��5.   9   �� *AbonementItems+ �� SelectedItem 6`   �� *SelectedProducts+��52      �� 53      .R�54      A�  A� Columns$ 2��6"   56      ��59      �� 5:      .R�5;      L   FFitnessCenter.Views.Windows.Main.UserControls.Abonements.AbonementItem  5<      5>      �� 5@   
   ���#CCFF00$	��500��6C   $��30��6O      LoginButtonStyle#��[  6[   $��2��6�   $��Оформить��6�   ��6   �� *
AddOrder+6�   5A      5B      