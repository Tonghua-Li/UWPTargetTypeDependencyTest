# UWPTargetTypeDependencyTest

This is a demo project on figuring why TargetType dependency property not working in UWP.
# How to test:
	1. Go to MainPage.xaml, line 38,
	2. Change TargetType to any test class, those test classes are located on the top level of this project. 
	3. Result: 
	..1. Only BlankPage1, MyUserControl1 class works fine.
	..2. DerivedUserControl although is ame as MyUserControl1, but will crash.