using FPT.Domain;
using LLMSharp.Google.Palm;
using Microsoft.AspNetCore.Mvc;
namespace APIChatGPT
{
    [ApiController]
    [Route("[controller]")]
    public class ChatCompletionController() : ControllerBase
    {

        [HttpPost("answer")]
        public async Task<IActionResult> Get(ChatGPTDto dto)
        {
            GooglePalmClient client = new GooglePalmClient("AIzaSyCiAA1m4u9_SE2pNFP2_VE0GS4_sTJjVdg");
            // var response = await client.GenerateTextAsync(question);
            List<PalmChatMessage> messages = new()
            {
                 new(dto.Question, "0"),
            };

            var response = await client.ChatAsync(messages, null, null);
            return Ok(response);
        }
    }
}