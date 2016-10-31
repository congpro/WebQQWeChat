﻿using System;
using WebWeChat.Im.Core;
using WebWeChat.Im.Module.Interface;

namespace WebWeChat.Im.Module.Impl
{
    public abstract class WeChatModule : IWeChatModule
    {
        protected WeChatModule(IWeChatContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            Context = context;
        }

        public virtual void Destroy()
        {
        }

        public IWeChatContext Context { get; }

        /// <summary>
        /// 可销毁
        /// </summary>
        public virtual void Dispose()
        {
        }
    }
}
