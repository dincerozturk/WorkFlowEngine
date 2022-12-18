using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using WorkFlowManager.Common.ViewModels;

namespace WorkFlowManager.Web.Infra
{
    //public class WorkFlowFormModelBinder : IModelBinder // DefaultModelBinder, 
    //{
    //    protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
    //    {
    //        var typeValue = bindingContext.ValueProvider.GetValue("WorkFlowFormType");

    //        var asmClass = (string)typeValue.ConvertTo(typeof(string));


    //        var serviceAsmPath = "WorkFlowManager.Common.Dto";

    //        Assembly asm = Assembly.Load(serviceAsmPath);
    //        Type type = asm.GetType(asmClass);

    //        if (!typeof(WorkFlowFormViewModel).IsAssignableFrom(type))
    //        {
    //            throw new InvalidOperationException("Bad Type");
    //        }
    //        var model = Activator.CreateInstance(type);
    //        bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => model, type);
    //        return model;
    //    }
    //}

    public class WorkFlowFormModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(WorkFlowFormViewModel))
            {
                return new BinderTypeModelBinder(typeof(WorkFlowFormModelBinder));
            }

            return null;
        }
    }

    public class WorkFlowFormModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            if (bindingContext.ModelType != typeof(WorkFlowFormViewModel))
            {
                return Task.CompletedTask;
            }

            string modelName = string.IsNullOrEmpty(bindingContext.BinderModelName)
                ? bindingContext.ModelName
                : bindingContext.BinderModelName;

            ValueProviderResult valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            string valueToBind = valueProviderResult.FirstValue;

            if (valueToBind == null /* or not valid somehow*/)
            {
                return Task.CompletedTask;
            }

            WorkFlowFormViewModel value = ParseMyTypeFromJsonString(valueToBind);

            bindingContext.Result = ModelBindingResult.Success(value);

            return Task.CompletedTask;
        }

        private WorkFlowFormViewModel ParseMyTypeFromJsonString(string valueToParse)
        {
            return new WorkFlowFormViewModel
            {
                // Parse JSON from 'valueToParse' and apply your magic here
            };
        }
        //public class MyRequestType
        //{
        //    [JsonConverter(typeof(UniversalDateTimeConverter))]
        //    public WorkFlowFormViewModel PropName { get; set; }

        //    public string OtherProp { get; set; }
        //}
    }
}