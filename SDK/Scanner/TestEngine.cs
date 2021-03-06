﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teflon.SDK.Core;

namespace Teflon.SDK.Scanner
{
    public class TestEngine
    {
        public Context Context { get; private set; }

        public int ErrorCode { get; private set; }
        public string ExtraMessage { get; set; }

        public TestEngine(Context context=null)
        {
            Context = context;
        }
        public virtual void Run(Product product)
        {
            DateTime start = DateTime.Now;
            ErrorCode = 0;
            try
            {
                product.Engine = this;
                ErrorCode = product.Run(Context);
                SetErrorcode(ErrorCode);
            }
            catch (TeflonDoubleAssertFailException e)
            {
                SetErrorcode(e.ErrorCode);
            }
            catch (TeflonBoolAssertFailException e)
            {
                SetErrorcode(e.ErrorCode);
            }
            catch (TeflonIntAssertFailException e)
            {
                SetErrorcode(e.ErrorCode);
            }
            catch (TeflonStringAssertFailException e)
            {
                SetErrorcode(e.ErrorCode);
            }
            catch (TeflonCommunicationException e)
            {
                SetErrorcode(e.ErrorCode);
            }
            finally
            {
                DoubleVariable time = (DateTime.Now - start).TotalSeconds;
                time.Name = "TotalTestTime";
                product.Dispose();
            }
        }
        public virtual void DebugRun(Product product,IEnumerable<string>names)
        {
            DateTime start = DateTime.Now;
            ErrorCode = 0;
            try
            {
                ErrorCode = product.DebugRun(names,Context);
                SetErrorcode(ErrorCode);
            }
            catch (TeflonDoubleAssertFailException e)
            {
                SetErrorcode(e.ErrorCode);
            }
            catch (TeflonBoolAssertFailException e)
            {
                SetErrorcode(e.ErrorCode);
            }
            catch (TeflonIntAssertFailException e)
            {
                SetErrorcode(e.ErrorCode);
            }
            catch (TeflonStringAssertFailException e)
            {
                SetErrorcode(e.ErrorCode);
            }
            catch (TeflonCommunicationException e)
            {
                SetErrorcode(e.ErrorCode);
            }
            finally
            {
                DoubleVariable time = (DateTime.Now - start).TotalSeconds;
                time.Name = "TotalTestTime";
                product.Dispose();
            }
        }
        private void SetErrorcode(int error_code)
        {
            this.ErrorCode = error_code;
            FailcodeVariable failcode = error_code;
            failcode.Name = "Failcode";
        }
    }
}
