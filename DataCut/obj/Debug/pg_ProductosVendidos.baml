   M S B A M L   `   `   `  ����B  >DataCut, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DataCutDataCut  5      "    DataCut.pg_ProductosVendidos   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:DataCut     5        N� Title$  pg_ProductosVendidos��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��8* �6   �� 5      $��1* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid_TR_list��5      
������� J� Opacity$	 0.9Q�6@      
IsReadOnly . 
������    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6z   $��16(�6�    � ContextMenu 5      �� 5      .@�5      m� -   5        $��Eliminar��5      61   5      5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $��3* �6#   �� 5      $��3* �6#   �� 5      $��1* �6#   �� 5      $��1* �6#    5      �� 5      $
��0.5* �6    �� 5       $��1* �6    .+�5"      (� .��5#      �� $��Producto��6   
�������$��16(�6?   $��Bottom=�6M   5$      (� 5%      $��1��6   .��5&      �� $��Cantidad��6   
�������$��16(�6?   $��1��6M   $��Bottom=�6]   5'      (� 5(      $��1��6   .��5)      �� -   5         ��Name$ cbx_PV_productos��5)      $	��170��65      	cbx_style#��[  6D   5*      (� 5+      $��1��6   $��1��6$   .��5,      �� -   5        	 ��Name$	 cbx_PV_cantidad��5,      $��Center=�64   $	��170��6X   5-      (� 5.      $��2��6   $��0��6&   $��2��63   $��5q�6D   .��5/      �� -   5        
 ��Name$
 bt_PV_ok��5/        bt_style#��[ 6+   
�������.��50      �� $��imagenes/save.png��6   51      52      (� 53      $��3��6   $��0��6&   $��2��63   $��5q�6D   .��54      �� -   5        $
 bt_PV_eliminar��54      #��[ 62   
�������.��55      �� $��imagenes/cancel.png��6   56      57      58      59      5:      