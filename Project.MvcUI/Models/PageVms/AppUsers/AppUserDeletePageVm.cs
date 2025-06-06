﻿using Project.MvcUI.Models.PureVms.RequestModels.AppUsers;
using Project.MvcUI.Models.PureVms.ResponseModels.AppUsers;

namespace Project.MvcUI.Models.PageVms.AppUsers
{
    /// <summary>
    /// Kullanıcı silme onay sayfası için istek/yanıt modellerini içerir.
    /// </summary>
    public class AppUserDeletePageVm
    {
        public AppUserDeleteRequestModel Request { get; set; } = new();
        public AppUserDeleteResponseModel Response { get; set; } = new();
    }
}
