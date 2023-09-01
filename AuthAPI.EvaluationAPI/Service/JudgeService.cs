﻿using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using System;
using System.Security.Policy;
using System.Text;
using Xphyrus.EvaluationAPI.Models.Dtos;
using Xphyrus.EvaluationAPI.Service.IService;

namespace Xphyrus.EvaluationAPI.Service
{
    public class JudgeService : IJudgeService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public JudgeService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<SubmissionStatusResponse> GetResponse(TokenResponse response)
        {
            var client = _httpClientFactory.CreateClient("Judge0");
            var resp = await client.GetAsync($"/submissions/" + response.token.ToString());
            var apiContent = await resp.Content.ReadAsStringAsync();
            var ress = JsonConvert.DeserializeObject<SubmissionStatusResponse>(apiContent);
            return ress;
            
            
        }

        public async Task<object> SubmitPost(SubmissionRequest request)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var uri = new Uri("http://localhost:2358/submissions/");
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {

                // Print response body
                var responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            else
            {
                return response.IsSuccessStatusCode;
            }
        }
           
    }

}
