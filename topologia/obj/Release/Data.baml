   M S B A M L   `   `   `  ���� D  @topologia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:br.corp.bonus630.topologiabr.corp.bonus630.topologia  %    br.corp.bonus630.topologia.Data   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     :local(clr-namespace:br.corp.bonus630.topologia       � Title$
  Data��$	��480��$	��900�� � 
ResizeMode$ NoResize=� J� CommandBindings )  #System.Windows.Input.CommandBinding  -      Command$	 New��  -   $
 Save��  -   $
 Open��  -   $ SaveAs��  -   .   (br.corp.bonus630.topologia.ConfigCommand   
ConfigOpen# Z   -   $ Close�� J� InputBindings �� 
 �� Key$ S�� �� 	Modifiers$ Controlf� �� Command$
 Save���� $ O��$ Controlf�$
 Open���� $ N��$ Controlf�$	 New���� $ S��$ Control+Shiftf�$ SaveAs���� $ U��$ Controlf�# Z �� $ W��$ Controlf�$ Close��.��� -   	 �Name$		 box��$��0,0,0,-2q�.+�o� $��24��$	��Top=����� 
 �� EndPoint$	
 0,1&� �� 
StartPoint$	 0,0&�.���  � Color$ 	#FFF6F6F6�� � Offset$
 0.25Q�� $ 	#FFEAE8E8��$ 0.101Q�� $ 	#FFDCD9D9��$ 0.931Q�� $ White��$ 1Q�.@�m� $��Caverna��$��24��$��83��.@�m� -    m�Name$ btn_novo��$
��Novo�� m� Command$ ApplicationCommands.New�� m� InputGestureText$ Ctrl+N��m� -	   $ btn_load��$��Carregar��$ ApplicationCommands.Open��$ Ctrl+O��m� -
   $ btn_save��$��Salvar��$ ApplicationCommands.Save��$ Ctrl+S��m� -   $ 
btn_saveas��$��Salvar Como��$  ApplicationCommands.SaveAs��$ Ctrl+Shift+S��m� $��Bases��$��83��$��24��.@�m� -   $ menuItem_add��$��	Adicionar��m� -   $ menuItem_edit��$��Editar��m� -   $ menuItem_remove��$��Remover��m� -   $ menuItem_clear��$��Limpar��m� $��Opções��$��83��$��24��.@�m� -   $ menuItem_config��$��Configurações��# Z $ Ctrl+U��m� -   $ menuItem_close��$��Fechar��$ ApplicationCommands.Close��$ Ctrl+W���� $
��Left=�$��0,24,0,0q�$	��428��$	��Top=�$	��894��.+��� $��Dados da Caverna�����	#00000000���	#FF780404$��14(���  �� Orientation$ 
Horizontal=�$��40��.+��� $��Nome:��$��Center=��� -   $��txt_caveName��$��26��$�� ��$��Center=�$	��0,7q�$	��270���� $��Data:��$��Center=�(  "System.Windows.Controls.DatePicker  -   $��datepicker_dateTopo��$��26��$��Center=��� �� $��Dados das Bases�����	#00000000���	#FF780404$��14(��� $ 
Horizontal=�$��40��.+��� -    ��Name$ 
cb_entrace��$��Entrada��$
��Left=�$��Center=� d� 	IsChecked$
 TrueY�$��16��$��66��� -   $��baseAnt��$y�	Collapsed=�$	��140��$��26��.+��� $��Da Base��$
��Left=�$��Center=�$��	0,0,-21,0q��� -    ��Name$ 
cb_baseAnt��$
��Left=�$��Center=�$��58��$��
79,0,-79,0q��� $��	Para Base��$
��Left=�$��Center=�$��26��$��64��$	��0,7q��� -    ��Name$ txt_baseName��$
��Left=�$��22�� �� TextWrapping$
 Wrap=�$��Center=�$��61���� -   $��stackPanel_teste��$ 
Horizontal=�$��40��� -   $��box_comments��$y�	Collapsed=�$��80��.+��� $��Comentários:���� -   $��txt_comments��$	��Top=� �� 	IsEnabled . $��80��$��	80,0,20,0q�� $��31��$��	17,0,10,0q�.+��� -    ��Name$ btn_add��$��	Adicionar��$
��Left=�$��75��$��12,4,0,5q�{�.  �� -   $ btn_edit��$��Editar��$
��Left=�$��75��$��	494,4,0,5q�{�.  �� -   $ 
btn_remove��$��Remover��$
��Left=�$��75��$��	574,4,0,5q�{�.  �� -   $ 	btn_clear��$��Limpar��$
��Left=�$��75��$��92,4,0,5q��� -    ��Name$ lba_baseTopoName��$�� ��$
��Left=�$��	654,2,0,0q�$	��Top=��� $	��194��$��0,0,10,0q�.��&   System.Windows.Controls.DataGrid  -      Name$ datagrid_base��   AutoGenerateColumns .  $	��Top=�   
IsReadOnly . $	��865��$
��Left=����� *
ListBase+   Columns 4  .System.Windows.Controls.DataGridCheckBoxColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Entrada��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	IsStart+  �� Mode$  OneWay=�0  *System.Windows.Controls.DataGridTextColumn  $ Da Base�� �� *RefBaseName+$  OneWay=�  $ 	Para Base�� �� *
BaseName+$  OneWay=�  $
 Cima�� �� *	TopSide+$  OneWay=�  $ Baixo�� �� *
BottomSide+$  OneWay=�  $ Esquerda�� �� *
LeftSide+$  OneWay=�  $ Direita�� �� *	RightSide+$  OneWay=�  $ Azymuti�� �� *	Azymuti+$  OneWay=�  $ Inclinação�� �� *Incrination+$  OneWay=�  $ 
Distância�� �� *
Distance+$  OneWay=�  $ Comentários�� �� *	Coments+$  OneWay=�