using System;
using System.Collections.Generic;
using System.Text;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using PrismAvaloniaWithMSDI.ViewModels;

namespace PrismAvaloniaWithMSDI
{
    internal class ViewLocator : IDataTemplate
    {
        public Control? Build(object? data)
        {
            if (data is null)
                return null;

            // 获取 ViewModel 的全名 (例如: MyProject.ViewModels.MainWindowViewModel)
            // 并将 "ViewModel" 替换为 "View" (变为: MyProject.Views.MainWindowView)
            var name = data.GetType().FullName!.Replace("ViewModel", "View");

            // 尝试根据字符串名称获取类型
            var type = Type.GetType(name);

            if (type != null)
            {
                // 如果找到了类型，则创建实例并强制转换为 Control
                return (Control)Activator.CreateInstance(type)!;
            }

            // 如果找不到，在界面上显示一个简单的 TextBlock 提示错误
            return new TextBlock { Text = "Not Found: " + name };
        }

        public bool Match(object? data)
        {
            // 只有当数据对象继承自 ViewModelBase 时，才使用此定位器
            return data is ViewModelBase;
        }
    }
}
