   M S B A M L   `   `   `  ����W  SYük Gemisi Yönetim Sistemi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Yük_Gemisi_Yönetim_SistemiYük_Gemisi_Yönetim_Sistemi  5   	   ,    &Yük_Gemisi_Yönetim_Sistemi.gemibakim   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Yük_Gemisi_Yönetim_Sistemi     5   	     � Title$
  Gemi��5   	   $	��500��6   $
��1000��6#   .��5	      � $��	3,-1,-3,1q�6    J� RenderTransformOrigin$ 0.575,0.492&�6   .+�5
   
   �� -   5         ��Name$ label��5
      $��	Gemi Adı��6   $
��Left=�62   $��
151,61,0,0q�6M   $	��Top=�6a   ���	#FF3399FF6y   �� 5   
   -   5        $ label1��5      $��Gemi Bakım Tarihi��6    $
��Left=�6<   $��151,145,0,0q�6W   $	��Top=�6l   ���	#FF3399FF6�   �� 5   
   -   5        $ label2��5      $��Gemi Seri Numarası��6    $
��Left=�6=   $��150,106,0,0q�6X   $	��Top=�6m   ���	#FF3399FF6�   �� 5   
   -   5        $ label3��5      $�� ��6    $
��Left=�6+   $��
22,166,0,0q�6F   $	��Top=�6Z   �� 5   
   -   5         ��Name$ textBox_gemiadı��5      $
��Left=�6+   $��23��6F   $��
271,68,0,0q�6R    �� TextWrapping$
 Wrap=�6f   $	��Top=�6z   $	��120��6�   
���   �6�   �� 5   
   -   5        $ textBox_serino��5      $
��Left=�6*   $��23��6E   $��280,109,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $	��120��6�   
���   �6�   �� 5   
   -   5        $ label4��5      $��Erzak Teslim Tarihi��6    $
��Left=�6>   $��149,187,0,0q�6Y   $	��Top=�6n   $ 0.526,0.308&�6�   ���	#FF3399FF6�   �� 5   
   -   5        $ label5��5      $��Temizlik Tarihi��6    $
��Left=�6:   $��149,231,0,0q�6U   $	��Top=�6j   ���	#FF3399FF6�   (  "System.Windows.Controls.DatePicker  5   
   -	   5          Name$ temizliktarih��5      $
��Left=�6,   $��271,236,0,0q�6G   $	��Top=�6\   
���   �6t     5   
   -
   5        $ erzakteslim��5      $
��Left=�6*   $��298,193,0,0q�6E   $	��Top=�6Z   ���	#FF0202026r     5   
   -   5        $ bakimtarihi��5      $
��Left=�6*   $��298,149,0,0q�6E   $	��Top=�6Z   
���   �6r   �� 5   
   -   5         ��Name$ button��5      $��Kaydet��6!   $
��Left=�62   $��346,305,0,0q�6M   $	��Top=�6b   $��84��6z   $��32��6�   ���	#FFEEEEEE���	#FF3399FF$��16(�6�   
�������6�   �� 5   
   -   5        $ label6��5      $
��Gemi��6    $
��Left=�6/   $��
243,10,0,0q�6J   $	��Top=�6^   ���	#FF3399FF$��16(�6�   �� 5   
   -   5        $ button2��5      $��Temizle��6"   $
��Left=�64   $��234,305,0,0q�6O   $	��Top=�6d   $��84��6|   ���	#FF3399FF$��32��6�   
����������	#FF3399FF$��16(�6�   �� 5   
   $
��Left=�6   $	��100��6/   $	��Top=�6<   $	��100��6T   ��5      �� 5       �� ImageSource$ images/logo2.jpg��6   5      �� 5   
   $
��Left=�6   $	��283��6/   $��
474,45,0,0q�6<   
�������$	��Top=�6_   $	��496��6w   ��5      �� 5      $9 3images/cargo-cargo-container-cargo-ship-1095814.jpg��6   5!      �� 5"   
   -   5        $ button3��5"      $��Göster��6"   $
��Left=�63   $	��Top=�6N   $��84��6f   $��126,305,0,0q�6q   $��32��6�   
����������	#FF3399FF$��16(�6�   
�������6�   �� 5#   
   -   5        $ button4��5#      $
��Geri��6"   $
��Left=�61   $��	0,113,0,0q�6L   $	��Top=�6_   $��75��6w   $��29��6�   ���	#FF06498B
�������6�   5%      5&      