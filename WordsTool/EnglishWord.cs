using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WordsTool
{
    public class EnglishWord
    {
        public string word
        {
            get;
            set;
        }
        public string prounce_uk
        {
            get;
            set;
        }
        public string prounce_us
        {
            get;
            set;
        }
        public string additional
        {
            get;
            set;
        }
        public string trans
        {
            get;
            set;
        }

        #region staticmethod
        private enum ModelType
        {
            //值类型
            Struct,
            Enum,

            //引用类型
            String,
            Object,
            Else
        }
        private static ModelType GetModelType(Type modelType)
        {
            if (modelType.IsEnum)//值类型
            {
                return ModelType.Enum;
            }
            if (modelType.IsValueType)//值类型
            {
                return ModelType.Struct;
            }
            else if (modelType == typeof(string))//引用类型 特殊类型处理
            {
                return ModelType.String;
            }
            else if (modelType == typeof(object))//引用类型 特殊类型处理
            {
                return ModelType.Object;
            }
            else//引用类型
            {
                return ModelType.Else;
            }
        }

        public static T DataRowToModel<T>(DataRow row)
        {
            T model;
            Type type = typeof(T);
            ModelType modelType = GetModelType(type);
            switch (modelType)
            {
                case ModelType.Struct://值类型
                    {
                        model = default(T);
                        if (row[0] != null)
                            model = (T)row[0];
                    }
                    break;
                case ModelType.Enum://值类型
                    {
                        model = default(T);
                        if (row[0] != null)
                        {
                            Type fiType = row[0].GetType();
                            if (fiType == typeof(int))
                            {
                                model = (T)row[0];
                            }
                            else if (fiType == typeof(string))
                            {
                                model = (T)Enum.Parse(typeof(T), row[0].ToString());
                            }
                        }
                    }
                    break;
                case ModelType.String://引用类型 c#对string也当做值类型处理
                    {
                        model = default(T);
                        if (row[0] != null)
                            model = (T)row[0];
                    }
                    break;
                case ModelType.Object://引用类型 直接返回第一行第一列的值
                    {
                        model = default(T);
                        if (row[0] != null)
                            model = (T)row[0];
                    }
                    break;
                case ModelType.Else://引用类型
                    {
                        model = System.Activator.CreateInstance<T>();//引用类型 必须对泛型实例化
                        #region MyRegion
                        //获取model中的属性
                        PropertyInfo[] modelPropertyInfos = type.GetProperties();
                        //遍历model每一个属性并赋值DataRow对应的列
                        foreach (PropertyInfo pi in modelPropertyInfos)
                        {
                            //获取属性名称
                            String name = pi.Name;
                            if (row.Table.Columns.Contains(name) && row[name] != null)
                            {
                                ModelType piType = GetModelType(pi.PropertyType);
                                switch (piType)
                                {
                                    case ModelType.Struct:
                                        {
                                            var value = Convert.ChangeType(row[name], pi.PropertyType);
                                            pi.SetValue(model, value, null);
                                        }
                                        break;
                                    case ModelType.Enum:
                                        {
                                            Type fiType = row[0].GetType();
                                            if (fiType == typeof(int))
                                            {
                                                pi.SetValue(model, row[name], null);
                                            }
                                            else if (fiType == typeof(string))
                                            {
                                                var value = (T)Enum.Parse(typeof(T), row[name].ToString());
                                                if (value != null)
                                                    pi.SetValue(model, value, null);
                                            }
                                        }
                                        break;
                                    case ModelType.String:
                                        {
                                            var value = Convert.ChangeType(row[name], pi.PropertyType);
                                            pi.SetValue(model, value, null);
                                        }
                                        break;
                                    case ModelType.Object:
                                        {
                                            pi.SetValue(model, row[name], null);
                                        }
                                        break;
                                    case ModelType.Else:
                                        throw new Exception("不支持该类型转换");
                                    default:
                                        throw new Exception("未知类型");
                                }
                            }
                        }
                        #endregion
                    }
                    break;
                default:
                    model = default(T);
                    break;
            }

            return model;
        }

        public static List<EnglishWord> DataTableToList(DataTable table)
        {
            List<EnglishWord> list = new List<EnglishWord>();
            foreach (DataRow item in table.Rows)
            {
                list.Add(DataRowToModel<EnglishWord>(item));
            }
            return list;
        }

        public static string GetID()
        {
            return Guid.NewGuid().ToString("N").ToUpper();
        }
        #endregion
    }
}
