   M S B A M L   `   `   `  ????  
SpiderLaiR(    "SpiderLaiR.UserControls.TextDialog   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   S OHandyControl, Version=3.4.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5   	   $	??300??5      $	??450??6'   $??Microsoft YaHei)?5   	   $??
ExtraLight"?6&     ? 
ResizeMode$  NoResize=?5	   	    ? WindowStartupLocation$ CenterScreen=?6    ? WindowStyle$
 None=?5
   	    ? AllowsTransparency$
 True??6   ??66   Z? .??5      ?? $??5q?6   
??????? ?? CornerRadius$ 15??6+   
???????$??1q?6P    J? Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$
 Gray??6      ShadowDepth$ 5Q?6,      
BlurRadius$ 5Q?6<   	   Opacity$		 0.3Q?6K   
   	Direction$
 0Q?6Y   ._?5   
   ?  ? RowDefinitions 5      ?? 5      $??30 ?6    ?? 5      .+?5      ?? ???#326CF3$ 	15,15,0,0??6*   ? 5      .+?5      %  HandyControl.Controls.Watermark  -   5          Name$ water_Title??5      $??15(?64   $
??Bold"?6B      
MarkMargin$
 10,0q?6T   6f   ?? 5      -   5         ??Name$ 	eventExit??5      $??Right=?6,   
?????? $	????5      $??../Assets/Fonts/#iconfont)?6,   
???????$??20(?5   C   $??0,0,10,0q?5      $??0,0,0,0q?6+   ??5   ,   Z? 5   =   ?? 5      -   5         ??Name$ 	txt_Title??5      $??Center=?5      $??Center=?67   
???????$??15(?5   /   $??Arial Black)?6=   5      ?? 5       $??1??6   .+?5!      ?? -   5        $ txt_Content??5!      $??Center=?61   $??
20,50,20,0q?6N   $??20(?5"      $
??Wrap=?6*   $??Microsoft YaHei)?6>   ?? 5$      -   5         ??Name$ stack_ExitSetting??5$   O   $??Center=?6   $y?Visible=?6:   $??0,20,0,0q?6j   .+?5%      ?? .+?5&      	?    RadioButtonIcon.Small#??[  6&   $??退出SpiderSharpLaiR??5'   "   $
??Left=?6>    d? 	IsChecked 6Y   ?? *isExit+	? 5)      #??[  6&   $??最小化到托盘??5*   "   $
??Left=?63    6N   ?? *isTray+5+      ?? 5,      $??记住我的选择??6   $
??Left=?5-      $??0,10,0,0q?6:    5,   0   ?? *	isChecked+5-   :   5.      5/      ?? 50      -   5        $??1??50      $??
确    定??6"   
??????????#326CF3$	??200??51   .   $??Bottom=?6:   $??0,0,0,20q?52      $??50??6+   $??25(?67   $??Microsoft YaHei)?6E   $
??Bold"?6b   ??50   F   Z? 52   b   53      54      55      