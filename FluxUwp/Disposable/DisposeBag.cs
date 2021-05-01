using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxUwp.Disposable
{
    public class DisposeBag : IDisposable
    {
        #region Members
        private List<IDisposable> Bag = new List<IDisposable>();
        #endregion

        public void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Core implementation of IDisposable
        /// </summary>
        /// <param name="disposing"></param>
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Bag.ForEach(obj =>
                {
                    try
                    {
                        obj.Dispose();
                    }
                    catch
                    {
                        throw;
                    }
                });
                this.Bag.Clear();
#if DEBUG
                Debug.WriteLine("DisposeBag done");
#endif
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public void Collect(IDisposable obj)
        {
            this.Bag.Add(obj);
        }
    }
}
