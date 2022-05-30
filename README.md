DynBindingDemo is a demonstration project using  the InvokeDLL class which allows you to execute methods from a DLL dynamically.
The DLL will be unloaded after using it so you can easily replace or update it at runtime.

To use InvokeDLL class, simply add it to your Visual Studio project, copy the DLL that needs to be   dynamically loaded in the same directory as your executable (bin/debug)

Here is  sample code:

```c#
private InvokeDLL dll;
private void btnBindAndRun_Click(object sender, EventArgs e)
{
     dll = new InvokeDLL();
     try
     {
         dll.Run(@"DynBindingDLL.dll", "PrintHello", "Today is: ", 2);
     }
     catch (TargetParameterCountException tpce)
     {
         MessageBox.Show(tpce.Message);
     }
     catch (MissingMethodException mme)  
     {
         MessageBox.Show(mme.Message);
     }
     catch (FileNotFoundException fne)
     {
         MessageBox.Show(fne.Message);
     }
     catch (Exception ex)
     {
         MessageBox.Show(ex.Message);
     }
}

private void btnUnload_Click(object sender, EventArgs e)
{
    dll?.UnloadDomain();
}
```

