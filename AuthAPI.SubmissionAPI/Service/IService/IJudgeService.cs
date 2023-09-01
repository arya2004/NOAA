﻿
using Xphyrus.SubmissionAPI.Models.Dtos;

namespace Xphyrus.SubmissionAPI.Service.IService
{
    public interface IJudgeService
    {
        Task<object> SubmitPost(SubmissionRequest request);
        Task<SubmissionStatusResponse> GetResponse(TokenResponse response);
    }
}
