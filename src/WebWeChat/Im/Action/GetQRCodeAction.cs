﻿using System.Drawing;
using Utility.HttpAction.Core;
using Utility.HttpAction.Event;
using WebWeChat.Im.Core;

namespace WebWeChat.Im.Action
{
    public class GetQRCodeAction : WebWeChatAction
    {
        /// <summary>
        /// 显示二维码
        /// </summary>
        /// <param name="context"></param>
        /// <param name="listener"></param>
        public GetQRCodeAction(IWeChatContext context, ActionEventListener listener) : base(context, listener)
        {
        }

        public override HttpRequestItem BuildRequest()
        {
            var req =  new HttpRequestItem(HttpMethodType.Post, string.Format(ApiUrls.GetQRCode, Session.Uuid));
            req.AddQueryValue("t", "webwx");
            req.AddQueryValue("_", Timestamp);
            req.ResultType = HttpResultType.Stream;
            return req;
        }

        public override ActionEvent HandleResponse(HttpResponseItem responseItem)
        {
            return NotifyActionEvent(ActionEventType.EvtOK, Image.FromStream(responseItem.ResponseStream));
        }
    }
}
