   M S B A M L   `   `   `  ����@  <audio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:audioaudio  5   	       audio.MainWindow   5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:audio     5   	     � Title$  Музыка��5	   	   $	��450��6   $	��800��6%   .��5
      �  � RowDefinitions 5   
   �� 5      5      �� 5      $	��250 �6   5      �� 5      5      �� 5      5       � ColumnDefinitions 5   
   �� 5      5      �� 5      5      �� 5      5      �� 5      5      �� 5      5      .+�5!   
   �� -   5        $
��file��5!      $��Выбрать папку��6   $��5��66   6J   �� 5"   
   -   5         ��Name$ songs��5"      $��1��6"   $��5��6/   6C   r� 5#   
   -   5         r�Name$ media��5#       r� LoadedBehavior$ Manual=�6&   6^   �� 5$   
   -   5         ��Name$ audio_Slider��5$      $��2��6'   $��5��64   6H   �� 5%   
   -   5         ��Name$ 	tbElapsed��5%      $��2��6'   $��5q�64   $��Bottom=�6?   $
��Left=�6Z   6w   �� 5&   
   -   5        $ tbRemaining��5&      $��2��6)   $��4��66   $��5q�6F   $��Bottom=�6Q   $��Right=�6l   6�   �� 5'   
   -   5         ��Name$
 Stop��5'      $��3��6   $��2��6,    &  "MaterialDesignIconForegroundButton#��[  6<   	 � ToolTip$	 MaterialDesignIconButton��6x   .��5(      '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$

 Play=�6&   5)      �� 5*   
   -   5        $ Repeat��5*      $��3��6!   $��0��6.   #��[  6>   $	 MaterialDesignIconButton��6z   .��5+        $
 CircleArrows=�6&   5,      �� 5-   
   -	   5        $	 Mix��5-      $��3��6   $��4��6+   #��[  6;   $	 MaterialDesignIconButton��6w   .��5.        $
 Shuffle=�6&   5/      �� 50   
   -
   5        $
 next��50      $��3��6   $��3��6,   #��[  6<   $	 MaterialDesignIconButton��6x   .��51        $
 	NextTitle=�6&   52      �� 53   
   -   5        $
 back��53      $��3��6   $��1��6,   #��[  6<   $	 MaterialDesignIconButton��6x   .��54        $
 TitleBackward=�6&   55      56      57      