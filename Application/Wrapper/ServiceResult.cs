using System.Collections.Generic;

namespace Application.Wrapper
{

   public class ServiceResult
    {


        public static ServiceResult Set(object data, IDictionary<string, List<string>> exceptions = default) => new(false, data, exceptions);

        private object _objResult;
        public static ServiceResult Success(object data) => new(true, data);
        public static ServiceResult Success() => new(true);
        public static ServiceResult Failed() => new(false);
        public static ServiceResult Done() => new(true);
        public bool Succeed { get; set; } = false;
        public IDictionary<string, List<string>> Exceptions { get; set; }

        public object ObjResult
        {
            get => _objResult;
            set
            {
                if (value is not null) Succeed = true;
                _objResult = value;
            }
        }

        public ServiceResult(bool succeed, object data = null, IDictionary<string, List<string>> exceptions = null)
        {
            Succeed = succeed;
            ObjResult = data;
            Exceptions = exceptions;
        }

        public ServiceResult()
        {
            Succeed = false;
            ObjResult = null;
            Exceptions = new Dictionary<string, List<string>>();
        }
        public ServiceResult(bool succeed, object data)
        {
            Succeed = false;
            ObjResult = data;
            
        }

    }


    public class ServiceResult<T>
    {
        public static ServiceResult Set(T data, IDictionary<string, List<string>> exceptions = default) => new(false, data, exceptions);

        private T _objResult;
        public static ServiceResult Success(object data) => new(true, data);
        public static ServiceResult Success() => new(true);
        public static ServiceResult Failed() => new(true);
        public static ServiceResult Done() => new(true);
        public bool Succeed { get; set; } = false;
        public IDictionary<string, List<string>> Exceptions { get; set; }

        public T ObjResult
        {
            get => _objResult;
            set
            {
                if (value is not null) Succeed = true;
                _objResult = value;
            }
        }

        public ServiceResult(bool succeed, T data, IDictionary<string, List<string>> exceptions = null)
        {
            Succeed = succeed;
            ObjResult = data;
            Exceptions = exceptions;
        }
        public ServiceResult(T data , bool succeed)
        {
            Succeed = succeed;
            ObjResult = data;

        }
 
        public ServiceResult(bool succeed)
        {
            Succeed = succeed;
        }
        public ServiceResult()
        {
            Succeed = false;
            Exceptions = new Dictionary<string, List<string>>();
        }
    }
}
