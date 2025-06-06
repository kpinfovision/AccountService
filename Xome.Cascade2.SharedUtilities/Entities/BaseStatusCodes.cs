using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xome.Cascade2.SharedUtilities.ResponseModels
{
    public abstract class BaseStatusCodes
    {
        public static class Common
        {
            public static string Ok = "200";

            public static string NotModified = "304";

            public static string BadRequest = "400";

            public static string Unauthorized = "401";

            public static string Forbidden = "401";

            public static string NotFound = "404";

            public static string NotAcceptable = "406";

            public static string Gone = "410";

            public static string EnhanceYourCalm = "420";

            public static string UnprocessableEntity = "422";

            public static string TooManyRequests = "429";

            public static string InternalServerError = "500";

            public static string BadGateway = "502";

            public static string ServiceUnavailable = "503";

            public static string GatewayTimeout = "504";

            public static string CustomMessage = "20";

            public static string CouldNotAuthenticate = "32";

            public static string PageDoesNotExists = "34";

            public static string CannotReportYourSelfForSpam = "36";

            public static string AttachmentUrlParamIsValid = "44";

            public static string UserNotFound = "50";

            public static string UserSuspended = "63";

            public static string AccountSuspended = "64";

            public static string ApiVersionNotActive = "68";

            public static string NotPermittedForThisAction = "87";

            public static string RateLimitExceeded = "88";

            public static string InvalidOrExpiredToken = "89";

            public static string SSLRequired = "92";

            public static string UnAuthorizedAccessForDirectMessages = "93";

            public static string UnableVerifyCredentials = "99";

            public static string OverCapacity = "130";

            public static string InternalError = "131";

            public static string CouldNotAuthenticateTimeOut = "135";

            public static string NoStatusFound = "144";

            public static string CantSendMessageToUserNotFollowed = "150";

            public static string ErrorWhileSendingMessage = "151";

            public static string UnableToFollowMorePeople = "161";

            public static string UnAuthorizedToSeeStatus = "179";

            public static string UserIsOverDailyStatusLimit = "185";

            public static string StatusDuplicate = "187";

            public static string OverLimitedSpamReports = "205";

            public static string BadAuthenticationData = "215";

            public static string CredentialsCanNotAccessResource = "220";

            public static string CannotCompleteActionRightRow = "226";

            public static string UserVerifyLogin = "231";

            public static string EndPointRetiredShouldNotUsed = "251";

            public static string CannotPerformWriteActions = "261";

            public static string CannotMuteYourself = "271";

            public static string NotMutingForOther = "272";

            public static string AnimatedGIFsAreNotAllowed = "323";

            public static string MediaIdsValidationFailed = "324";

            public static string MediaIdNotFound = "325";

            public static string AccountTemporarilyLocked = "326";

            public static string DirectMessageExceedsMaxLength = "354";

            public static string TweetIsDeletedOrNotVisible = "385";

            public static string TweetExceedsAttachmentCount = "386";

            public static string FileConfigurationNotFound = "1001";

            public static string FileExtenstionNotAllowed = "1002";

            public static string FileExceedsMaxSize = "1003";
        }
    }
}
