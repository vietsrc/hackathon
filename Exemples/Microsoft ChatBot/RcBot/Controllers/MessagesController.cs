using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using RCBot.Helpers.DTO.LineUp;
using RCBot.Helpers;
using System.Collections.Generic;
using System.Web;
using RcBot.Extensions;

namespace RCBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        private MessagesController() {
        }

        /// <summary>
        /// POST: api/Messages
        /// Recois un msg de l'usgaer et on y retourne une reponse
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message && activity.Text.ToLower() == "/random")
            {
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));

                LineUp lineUp = RcHelpers.GetLineUp(RcContants_LineUp.REGION_GRAND_MTL);

                // Va chercher un index aleatoire 
                var randomIndex = new Random(DateTime.Now.Millisecond).Next(0, lineUp.pagedList.items.Count - 1);

                // On extrait du tableau, l'article que nous voulons montrer a l'usager
                var article = lineUp.pagedList.items[randomIndex];

                // Extraction du url de l'image
                var imageUrl = article.summaryMultimediaItem.concreteImages?.Find(x => x.dimensionRatio == "4:3")?.mediaLink.href;

                // Converti l'image en grandeur utilisable
                var imageBase64 = string.Empty;
                if (!string.IsNullOrEmpty(imageUrl)) {
                    var base64 = imageUrl.TransformUrlToScaledImage();
                    imageBase64 = imageUrl.EndsWith("png") ? "data:image/png;base64," + base64 : "data:image/jpg;base64," + base64;
                }

                Activity reply = activity.CreateReply("");
                reply.Recipient = activity.From;
                reply.Type = "message";
                reply.Attachments = new List<Attachment>();

                // Construit l'image en reponse
                List<CardImage> cardImages = new List<CardImage>();
                cardImages.Add(new CardImage(url: imageBase64));

                // Construit l'action qui va aller avec l'image
                List<CardAction> cardButtons = new List<CardAction>();
                CardAction plButton = new CardAction()
                {
                    Value = article.canonicalWebLink.href,
                    Type = "openUrl",
                    Title = "Voir plus"
                };
                cardButtons.Add(plButton);

                // Construit la carte
                HeroCard plCard = new HeroCard()
                {
                    Title = HttpUtility.HtmlDecode(article.title),
                    Subtitle = "",
                    Images = cardImages,
                    Buttons = cardButtons
                };

                Attachment plAttachment = plCard.ToAttachment();
                reply.Attachments.Add(plAttachment);

                await connector.Conversations.ReplyToActivityAsync(reply);
            }
            else if(activity.Type == ActivityTypes.Message)
            {
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                Activity reply = activity.CreateReply("Je ne connais qu'une commande. Utilisez /random");

                await connector.Conversations.ReplyToActivityAsync(reply);
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}
 