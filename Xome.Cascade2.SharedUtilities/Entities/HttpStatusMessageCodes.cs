using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xome.Cascade2.SharedUtilities.ResponseModels
{
    public static class HttpStatusMessageCodes
    {
        public static readonly List<HttpStatusMessage> statusMessages;

        static HttpStatusMessageCodes()
        {
            statusMessages = new List<HttpStatusMessage>
        {
            new HttpStatusMessage
            {
                Code = "1001",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "A file configuration was not found for the '{0}' feature",
                HttpStatusMessageId = "1001_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "1001",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "No se encontr\ufffd una configuraci\ufffdn de archivo para la funci\ufffdn '{0}'",
                HttpStatusMessageId = "1001_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "1002",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "'{0}' is not allowed. Files must have these file extension(s): '{1}'",
                HttpStatusMessageId = "1002_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "1002",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "'{0}' no est\ufffd permitido. Los archivos deben tener estas extensiones de archivo: '{1}'",
                HttpStatusMessageId = "1002_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "1003",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "'{0}' is not allowed. The file size is '{1} kb', which exceeds the '{2} kb' maximum",
                HttpStatusMessageId = "1003_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "1003",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "'{0}' no est\ufffd permitido. El tama\ufffdo del archivo es '{1} kb', que excede el m\ufffdximo '{2} kb'",
                HttpStatusMessageId = "1003_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "130",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 503 - PrimeroEdge is temporarily over capacity.",
                HttpStatusMessageId = "130_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "130",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde con HTTP 503: PrimeroEdge est\ufffd temporalmente sobrecargado.",
                HttpStatusMessageId = "130_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "131",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 500 - An unknown internal error occurred.",
                HttpStatusMessageId = "131_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "131",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde con HTTP 500: se produjo un error interno desconocido.",
                HttpStatusMessageId = "131_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "135",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 401 - Timestamp out of bounds (check your system clock)",
                HttpStatusMessageId = "135_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "135",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde con HTTP 401 - Marca de tiempo fuera de l\ufffdmites (verifique el reloj de su sistema)",
                HttpStatusMessageId = "135_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "144",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 404 - the requested Tweet ID is not found (if it existed, it was probably deleted)",
                HttpStatusMessageId = "144_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "144",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde con HTTP 404: no se encuentra la ID de Tweet solicitada (si exist\ufffda, probablemente se elimin\ufffd)",
                HttpStatusMessageId = "144_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "150",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 403 \ufffd sending a Direct Message failed",
                HttpStatusMessageId = "150_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "150",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde con HTTP 403: no se pudo enviar un mensaje directo",
                HttpStatusMessageId = "150_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "151",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 403 \ufffd sending a Direct Message failed. The reason value will provide more information.",
                HttpStatusMessageId = "151_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "151",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde a HTTP 403: no se pudo enviar un mensaje directo. El valor del motivo proporcionar\ufffd m\ufffds informaci\ufffdn.",
                HttpStatusMessageId = "151_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "161",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 403 \ufffd thrown when a user cannot follow another user due to some kind of limit",
                HttpStatusMessageId = "161_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "161",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde con HTTP 403: se lanza cuando un usuario no puede seguir a otro usuario debido a alg\ufffdn tipo de l\ufffdmite",
                HttpStatusMessageId = "161_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "179",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 403 \ufffd thrown when a Tweet cannot be viewed by the authenticating user, usually due to the Tweet\ufffds author having protected their Tweets.",
                HttpStatusMessageId = "179_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "179",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde con HTTP 403: lanzado cuando un usuario de autenticaci\ufffdn no puede ver un Tweet, generalmente debido a que el autor del Tweet ha protegido sus Tweets.",
                HttpStatusMessageId = "179_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "185",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 403 \ufffd thrown when a Tweet cannot be posted due to the user having no allowance remaining to post. Despite the text in the error message indicating that this error is only thrown when a daily limit is reached, this error will be thrown whenever a posting limitation has been reached. Posting allowances have roaming windows of time of unspecified duration.",
                HttpStatusMessageId = "185_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "185",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde con HTTP 403: se lanza cuando no se puede publicar un Tweet debido a que el usuario no tiene permiso para publicar. A pesar del texto en el mensaje de error que indica que este error solo se produce cuando se alcanza un l\ufffdmite diario, este error se generar\ufffd siempre que se haya alcanzado una limitaci\ufffdn de publicaci\ufffdn. Los derechos de publicaci\ufffdn tienen ventanas de tiempo de itinerancia de duraci\ufffdn no especificada.",
                HttpStatusMessageId = "185_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "187",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "The status text has already been Tweeted by the authenticated account.",
                HttpStatusMessageId = "187_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "187",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "El texto de estado ya ha sido twitteado por la cuenta autenticada.",
                HttpStatusMessageId = "187_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "200",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Success!",
                HttpStatusMessageId = "200_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "200",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Success!",
                HttpStatusMessageId = "200_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "205",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 403. The account limit for reporting spam has been reached. Try again later.",
                HttpStatusMessageId = "205_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "205",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde con HTTP 403. Se ha alcanzado el l\ufffdmite de cuenta para informar spam. Intenta nuevamente m\ufffds tarde.",
                HttpStatusMessageId = "205_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "215",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Typically sent with 1.1 responses with HTTP code 400. The method requires authentication but it was not presented or was wholly invalid.",
                HttpStatusMessageId = "215_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "215",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Normalmente se env\ufffda con respuestas 1.1 con el c\ufffddigo HTTP 400. El m\ufffdtodo requiere autenticaci\ufffdn, pero no se present\ufffd o fue completamente inv\ufffdlido.",
                HttpStatusMessageId = "215_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "220",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 403. The authentication token in use is restricted and cannot access the requested resource.",
                HttpStatusMessageId = "220_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "220",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde a HTTP 403. El token de autenticaci\ufffdn en uso est\ufffd restringido y no puede acceder al recurso solicitado.",
                HttpStatusMessageId = "220_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "226",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "We constantly monitor and adjust our filters to block spam and malicious activity on the PrimeroEdge platform. These systems are tuned in real-time. If you get this response our systems have flagged the Tweet or DM as possibly fitting this profile. If you feel that the Tweet or DM you attempted to create was flagged in error, please report the details around that to us by filing a ticket at https://support.PrimeroEdge.com/forms/platform .",
                HttpStatusMessageId = "226_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "226",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Controlamos y ajustamos constantemente nuestros filtros para bloquear el spam y la actividad maliciosa en la plataforma PrimeroEdge. Estos sistemas est\ufffdn sintonizados en tiempo real. Si recibe esta respuesta, nuestros sistemas han marcado el Tweet o el DM como posiblemente adecuado para este perfil. Si cree que el Tweet o DM que intent\ufffd crear se marc\ufffd por error, inf\ufffdrmenos los detalles al respecto al presentar un ticket en https://support.PrimeroEdge.com/forms/platform.",
                HttpStatusMessageId = "226_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "231",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Returned as a challenge in xAuth when the user has login verification enabled on their account and needs to be directed to PrimeroEdge.com to generate a temporary password .",
                HttpStatusMessageId = "231_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "231",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Devuelto como un desaf\ufffdo en xAuth cuando el usuario tiene habilitada la verificaci\ufffdn de inicio de sesi\ufffdn en su cuenta y necesita ser dirigido a PrimeroEdge.com para generar una contrase\ufffda temporal.",
                HttpStatusMessageId = "231_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "251",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds to a HTTP request to a retired URL.",
                HttpStatusMessageId = "251_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "251",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde a una solicitud HTTP a una URL retirada.",
                HttpStatusMessageId = "251_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "261",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 403 \ufffd thrown when the application is restricted from POST, PUT, or DELETE actions. See How to appeal application suspension and other disciplinary actions .",
                HttpStatusMessageId = "261_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "261",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde con HTTP 403: se lanza cuando la aplicaci\ufffdn est\ufffd restringida de acciones POST, PUT o DELETE. Consulte C\ufffdmo apelar la suspensi\ufffdn de la solicitud y otras acciones disciplinarias.",
                HttpStatusMessageId = "261_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "271",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 403. The authenticated user account cannot mute itself.",
                HttpStatusMessageId = "271_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "271",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde con HTTP 403. La cuenta de usuario autenticada no puede silenciarse.",
                HttpStatusMessageId = "271_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "272",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 403. The authenticated user account is not muting the account a call is attempting to unmute.",
                HttpStatusMessageId = "272_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "272",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde con HTTP 403. La cuenta de usuario autenticada no est\ufffd silenciando la cuenta que una llamada est\ufffd intentando activar.",
                HttpStatusMessageId = "272_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "304",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "There was no new data to return.",
                HttpStatusMessageId = "304_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "304",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "No hubo nuevos datos para devolver.",
                HttpStatusMessageId = "304_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "323",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 400. Only one animated GIF is allowed to be attached to a single Tweet",
                HttpStatusMessageId = "323_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "323",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde con HTTP 400. Solo se permite adjuntar un GIF animado a un solo Tweet",
                HttpStatusMessageId = "323_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "324",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 400. There was a problem with the media ID submitted with the Tweet.",
                HttpStatusMessageId = "324_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "324",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde con HTTP 400. Hubo un problema con el ID de medios enviado con el Tweet.",
                HttpStatusMessageId = "324_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "325",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 400. The media ID attached to the Tweet was not foun",
                HttpStatusMessageId = "325_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "325",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde con HTTP 400. No se encontr\ufffd la identificaci\ufffdn de medios adjunta al Tweet",
                HttpStatusMessageId = "325_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "326",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 403. The user should log in to https://PrimeroEdge.com to unlock their account.",
                HttpStatusMessageId = "326_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "326",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde a HTTP 403. El usuario debe iniciar sesi\ufffdn en https://PrimeroEdge.com para desbloquear su cuenta.",
                HttpStatusMessageId = "326_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "32",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Your call could not be completed as dialed.",
                HttpStatusMessageId = "32_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "32",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Su llamada no se pudo completar como se marc\ufffd.",
                HttpStatusMessageId = "32_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "34",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 404 - the specified resource was not found.",
                HttpStatusMessageId = "34_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "34",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde a HTTP 404: no se encontr\ufffd el recurso especificado.",
                HttpStatusMessageId = "34_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "354",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 403. The message size exceeds the number of characters permitted in a direct message.",
                HttpStatusMessageId = "354_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "354",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde con HTTP 403. El tama\ufffdo del mensaje excede el n\ufffdmero de caracteres permitidos en un mensaje directo.",
                HttpStatusMessageId = "354_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "36",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 403. You cannot use your own user ID in a report spam call.",
                HttpStatusMessageId = "36_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "36",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde a HTTP 403. No puede usar su propia ID de usuario en una llamada de informe de spam.",
                HttpStatusMessageId = "36_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "385",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 403. A reply can only be sent with reference to an existing public Tweet.",
                HttpStatusMessageId = "385_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "385",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde con HTTP 403. Una respuesta solo se puede enviar con referencia a un Tweet p\ufffdblico existente.",
                HttpStatusMessageId = "385_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "386",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 403. A Tweet is limited to a single attachment resource (media, Quote Tweet, etc.)",
                HttpStatusMessageId = "386_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "386",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde con HTTP 403. Un Tweet est\ufffd limitado a un solo recurso de archivo adjunto (medios, Cotizaci\ufffdn de Tweet, etc.)",
                HttpStatusMessageId = "386_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "400",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "The request was invalid or cannot be otherwise served. An accompanying error message will explain further. Requests without authentication are considered invalid and will yield this response.",
                HttpStatusMessageId = "400_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "400",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "La solicitud no era v\ufffdlida o no se puede atender de otra manera. Un mensaje de error que lo acompa\ufffda explicar\ufffd m\ufffds a fondo. Las solicitudes sin autenticaci\ufffdn se consideran inv\ufffdlidas y generar\ufffdn esta respuesta.",
                HttpStatusMessageId = "400_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "401",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Missing or incorrect authentication credentials. Also returned in other circumstances (for example, all calls to API v1 endpoints return 401).",
                HttpStatusMessageId = "401_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "401",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Credenciales de autenticaci\ufffdn faltantes o incorrectas. Tambi\ufffdn se devuelve en otras circunstancias (por ejemplo, todas las llamadas a puntos finales API v1 devuelven 401).",
                HttpStatusMessageId = "401_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "403",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "The request is understood, but it has been refused or access is not allowed. An accompanying error message will explain why. This code is used when requests are being denied due to update limits . Other reasons for this status being returned are listed alongside the response codes in the table below.",
                HttpStatusMessageId = "403_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "403",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "La solicitud se entiende, pero se ha rechazado o no se permite el acceso. Un mensaje de error adjunto explicar\ufffd por qu\ufffd. Este c\ufffddigo se utiliza cuando se rechazan solicitudes debido a l\ufffdmites de actualizaci\ufffdn. Otros motivos para que se devuelva este estado se enumeran junto con los c\ufffddigos de respuesta en la tabla a continuaci\ufffdn.",
                HttpStatusMessageId = "403_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "404",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "The URI requested is invalid or the resource requested, such as a user, does not exists. Also returned when the requested format is not supported by the requested method.",
                HttpStatusMessageId = "404_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "404",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "El URI solicitado no es v\ufffdlido o el recurso solicitado, como un usuario, no existe. Tambi\ufffdn se devuelve cuando el formato solicitado no es compatible con el m\ufffdtodo solicitado.",
                HttpStatusMessageId = "404_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "406",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Returned when an invalid format is specified in the request.",
                HttpStatusMessageId = "406_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "406",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Se devuelve cuando se especifica un formato no v\ufffdlido en la solicitud.",
                HttpStatusMessageId = "406_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "410",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "This resource is gone. Used to indicate that an API endpoint has been turned off.",
                HttpStatusMessageId = "410_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "410",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Este recurso se ha ido. Se utiliza para indicar que un punto final de API se ha desactivado.",
                HttpStatusMessageId = "410_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "420",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Returned when an application is being rate limited.",
                HttpStatusMessageId = "420_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "420",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Se devuelve cuando una solicitud tiene una tasa limitada.",
                HttpStatusMessageId = "420_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "422",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "server was unable to process the request because it contains invalid data",
                HttpStatusMessageId = "422_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "429",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Returned when a request cannot be served due to the application\ufffds rate limit having been exhausted for the resource. See Rate Limiting.",
                HttpStatusMessageId = "429_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "429",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Se devuelve cuando no se puede atender una solicitud debido a que el l\ufffdmite de tarifa de la aplicaci\ufffdn se ha agotado para el recurso. Ver Limitaci\ufffdn de velocidad.",
                HttpStatusMessageId = "429_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "44",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 400. The URL value provided is not a URL that can be attached to this Tweet.",
                HttpStatusMessageId = "44_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "44",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde con HTTP 400. El valor de URL proporcionado no es una URL que se pueda adjuntar a este Tweet.",
                HttpStatusMessageId = "44_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "500",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Something is broken. Please post to the developer forums with additional details of your request, in case others are having similar issues.",
                HttpStatusMessageId = "500_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "500",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Algo est\ufffd roto. Publique en los foros de desarrolladores con detalles adicionales de su solicitud, en caso de que otros tengan problemas similares.",
                HttpStatusMessageId = "500_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "502",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Xome is down or being upgraded.",
                HttpStatusMessageId = "502_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "502",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Xome est\ufffd abajo o est\ufffd siendo actualizada.",
                HttpStatusMessageId = "502_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "503",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "The Xome servers are up, but overloaded with requests. Try again later.",
                HttpStatusMessageId = "503_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "503",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Los servidores Xome est\ufffdn activos, pero sobrecargados de solicitudes. Intenta nuevamente m\ufffds tarde.",
                HttpStatusMessageId = "503_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "504",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "The Xome servers are up, but the request couldn\ufffdt be serviced due to some failure within our stack. Try again later.",
                HttpStatusMessageId = "504_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "504",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Los servidores Xome est\ufffdn activos, pero la solicitud no pudo ser atendida debido a alguna falla dentro de nuestra pila. Intenta nuevamente m\ufffds tarde.",
                HttpStatusMessageId = "504_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "50",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 404. The user is not found.",
                HttpStatusMessageId = "50_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "50",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde con HTTP 404. El usuario no se encuentra.",
                HttpStatusMessageId = "50_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "63",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "The user account has been suspended and information cannot be retrieved.",
                HttpStatusMessageId = "63_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "63",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "La cuenta de usuario se ha suspendido y la informaci\ufffdn no se puede recuperar.",
                HttpStatusMessageId = "63_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "64",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 403 \ufffd the access token being used belongs to a suspended user and they can\ufffdt complete the action you\ufffdre trying to take.",
                HttpStatusMessageId = "64_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "64",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde a HTTP 403: el token de acceso que se utiliza pertenece a un usuario suspendido y no puede completar la acci\ufffdn que est\ufffd intentando realizar.",
                HttpStatusMessageId = "64_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "68",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds to an HTTP request to a retired v1-era URL.",
                HttpStatusMessageId = "68_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "68",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde a una solicitud HTTP a una URL retirada de la era v1.",
                HttpStatusMessageId = "68_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "87",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 403. The endpoint called is not a permitted URL.",
                HttpStatusMessageId = "87_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "87",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde con HTTP 403. El punto final llamado no es una URL permitida.",
                HttpStatusMessageId = "87_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "88",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "The request limit for this resource has been reached for the current rate limit window.",
                HttpStatusMessageId = "88_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "88",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Se ha alcanzado el l\ufffdmite de solicitud para este recurso para la ventana de l\ufffdmite de velocidad actual.",
                HttpStatusMessageId = "88_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "89",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "The access token used in the request is incorrect or has expired",
                HttpStatusMessageId = "89_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "89",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "El token de acceso utilizado en la solicitud es incorrecto o ha expirado",
                HttpStatusMessageId = "89_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "92",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Only SSL connections are allowed in the API, you should update your request to a secure connection. See how to connect using TLS",
                HttpStatusMessageId = "92_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "92",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Solo se permiten conexiones SSL en la API, debe actualizar su solicitud a una conexi\ufffdn segura. Vea c\ufffdmo conectarse usando TLS",
                HttpStatusMessageId = "92_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "93",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 403. The OAuth token does not provide access to Direct Messages.",
                HttpStatusMessageId = "93_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "93",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde con HTTP 403. El token de OAuth no proporciona acceso a mensajes directos.",
                HttpStatusMessageId = "93_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "99",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponds with HTTP 403. The OAuth credentials cannot be validated. Check that the token is still valid.",
                HttpStatusMessageId = "99_-10_1",
                IsActive = true,
                LanguageId = 1,
                RegionId = -10
            },
            new HttpStatusMessage
            {
                Code = "99",
                CreatedBy = -10,
                CreatedDate = new DateTime(2024, 1, 1),
                Description = "Corresponde con HTTP 403. Las credenciales de OAuth no se pueden validar. Comprueba que el token sigue siendo v\ufffdlido.",
                HttpStatusMessageId = "99_-10_2",
                IsActive = true,
                LanguageId = 2,
                RegionId = -10
            }
        };
        }
    }
}
