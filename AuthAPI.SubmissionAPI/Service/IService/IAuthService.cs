﻿
using Xphyrus.SubmissionAPI.Models.Dtos;
using Xphyrus.SubmissionAPI.Models.ResReq;

namespace Xphyrus.SubmissionAPI.Service.IService
{
    public interface IAuthService
    {
        Task<ResponseDto> MarkSubmission(SubmissionDto regStartNotSubDto);
        

    }
}
