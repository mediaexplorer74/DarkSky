// <copyright file="SourceGenerationContext.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using IdentityModel.OidcClient;
using IdentityModel.OidcClient.DPoP;

namespace FishyFlip;

/// <summary>
/// ATProtocol Message Source Generation Context.
/// </summary>
[JsonSourceGenerationOptions(
    WriteIndented = true,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    GenerationMode = JsonSourceGenerationMode.Metadata,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
[JsonSerializable(typeof(Embed))]
[JsonSerializable(typeof(CreateBlockRecord))]
[JsonSerializable(typeof(CreateFollowRecord))]
[JsonSerializable(typeof(CreateLikeRecord))]
[JsonSerializable(typeof(CreateListRecord))]
[JsonSerializable(typeof(CreateListItemRecord))]
[JsonSerializable(typeof(CreateInviteCode))]
[JsonSerializable(typeof(CreateInviteCodes))]
[JsonSerializable(typeof(CreateRepostRecord))]
[JsonSerializable(typeof(CreatePostRecord))]
[JsonSerializable(typeof(CreatePostResponse))]
[JsonSerializable(typeof(CreateMuteRecord))]
[JsonSerializable(typeof(CreateMuteListRecord))]
[JsonSerializable(typeof(CreateModerationReportPost))]
[JsonSerializable(typeof(CreateModerationReportRepo))]
[JsonSerializable(typeof(CreateSeenAtRecord))]
[JsonSerializable(typeof(CreateThreadGateRecord))]
[JsonSerializable(typeof(DeleteRecord))]
[JsonSerializable(typeof(Login))]
[JsonSerializable(typeof(FeedResultList))]
[JsonSerializable(typeof(PutPostRecord))]
[JsonSerializable(typeof(UpdateHandle))]
[JsonSerializable(typeof(AccountInviteCode))]
[JsonSerializable(typeof(AccountInviteCodes))]
[JsonSerializable(typeof(ActorBlocks))]
[JsonSerializable(typeof(ActorFollows))]
[JsonSerializable(typeof(ActorFollowers))]
[JsonSerializable(typeof(ActorMutes))]
[JsonSerializable(typeof(ActorProfile))]
[JsonSerializable(typeof(ActorRecord))]
[JsonSerializable(typeof(ActorResponse))]
[JsonSerializable(typeof(AdminRepoRef))]
[JsonSerializable(typeof(AppPassword))]
[JsonSerializable(typeof(AppPasswords))]
[JsonSerializable(typeof(ATDid))]
[JsonSerializable(typeof(ATFeedTypeAPI))]
[JsonSerializable(typeof(ATHandle))]
[JsonSerializable(typeof(ATIdentifier))]
[JsonSerializable(typeof(ATUri))]
[JsonSerializable(typeof(Blob))]
[JsonSerializable(typeof(BlobRecord))]
[JsonSerializable(typeof(Block))]
[JsonSerializable(typeof(BlockRecord))]
[JsonSerializable(typeof(BSList))]
[JsonSerializable(typeof(BSListItem))]
[JsonSerializable(typeof(CommitPath))]
[JsonSerializable(typeof(DescribeRepo))]
[JsonSerializable(typeof(DescribeServer))]
[JsonSerializable(typeof(Embed))]
[JsonSerializable(typeof(ATError))]
[JsonSerializable(typeof(ErrorBody))]
[JsonSerializable(typeof(ErrorDetail))]
[JsonSerializable(typeof(External))]
[JsonSerializable(typeof(ExternalEmbed))]
[JsonSerializable(typeof(ExternalViewEmbed))]
[JsonSerializable(typeof(Facet))]
[JsonSerializable(typeof(FacetFeature))]
[JsonSerializable(typeof(FacetIndex))]
[JsonSerializable(typeof(FeedCollection))]
[JsonSerializable(typeof(FeedGenerator))]
[JsonSerializable(typeof(FeedGeneratorRecord))]
[JsonSerializable(typeof(FeedPostList))]
[JsonSerializable(typeof(FeedProfile))]
[JsonSerializable(typeof(FeedProfiles))]
[JsonSerializable(typeof(FeedRecord))]
[JsonSerializable(typeof(FeedViewPost))]
[JsonSerializable(typeof(FeedViewPostReply))]
[JsonSerializable(typeof(Follow))]
[JsonSerializable(typeof(FollowRecord))]
[JsonSerializable(typeof(FrameCommit))]
[JsonSerializable(typeof(FrameError))]
[JsonSerializable(typeof(FrameFooter))]
[JsonSerializable(typeof(FrameHeader))]
[JsonSerializable(typeof(FrameHeaderOperation))]
[JsonSerializable(typeof(FrameHandle))]
[JsonSerializable(typeof(FrameInfo))]
[JsonSerializable(typeof(FrameMigrate))]
[JsonSerializable(typeof(FrameNode))]
[JsonSerializable(typeof(FrameRepoOp))]
[JsonSerializable(typeof(FrameTombstone))]
[JsonSerializable(typeof(GeneratorFeed))]
[JsonSerializable(typeof(GeneratorView))]
[JsonSerializable(typeof(HandleResolution))]
[JsonSerializable(typeof(Head))]
[JsonSerializable(typeof(Image))]
[JsonSerializable(typeof(ImageEmbed))]
[JsonSerializable(typeof(ImageRef))]
[JsonSerializable(typeof(ImagesEmbed))]
[JsonSerializable(typeof(ImageViewEmbed))]
[JsonSerializable(typeof(InviteCode))]
[JsonSerializable(typeof(InviteCodes))]
[JsonSerializable(typeof(Label))]
[JsonSerializable(typeof(LatestCommit))]
[JsonSerializable(typeof(Like))]
[JsonSerializable(typeof(LikeRecord))]
[JsonSerializable(typeof(LikesFeed))]
[JsonSerializable(typeof(ListRecord<ATRecord>))]
[JsonSerializable(typeof(ListItemRecord))]
[JsonSerializable(typeof(ListItemView))]
[JsonSerializable(typeof(ListItemViewRecord))]
[JsonSerializable(typeof(ListBlobs))]
[JsonSerializable(typeof(ListFeed))]
[JsonSerializable(typeof(ListRecords<ATRecord>))]
[JsonSerializable(typeof(ListView))]
[JsonSerializable(typeof(ListViewRecord))]
[JsonSerializable(typeof(ModerationReasonType))]
[JsonSerializable(typeof(ModerationSubject))]
[JsonSerializable(typeof(ModerationRecord))]
[JsonSerializable(typeof(Notification))]
[JsonSerializable(typeof(NotificationCollection))]
[JsonSerializable(typeof(Ops))]
[JsonSerializable(typeof(Post))]
[JsonSerializable(typeof(PostCollection))]
[JsonSerializable(typeof(PostRecord))]
[JsonSerializable(typeof(PostView))]
[JsonSerializable(typeof(PostViewEmbed))]
[JsonSerializable(typeof(Profile))]
[JsonSerializable(typeof(ReasonRepost))]
[JsonSerializable(typeof(RecordEmbed))]
[JsonSerializable(typeof(RecordRef))]
[JsonSerializable(typeof(RecordViewEmbed))]
[JsonSerializable(typeof(RecordWithMediaEmbed))]
[JsonSerializable(typeof(RecordWithMediaViewEmbed))]
[JsonSerializable(typeof(Reply))]
[JsonSerializable(typeof(ReplyRef))]
[JsonSerializable(typeof(RepoList))]
[JsonSerializable(typeof(RepoList))]
[JsonSerializable(typeof(RepoRef))]
[JsonSerializable(typeof(Repost))]
[JsonSerializable(typeof(RepostedFeed))]
[JsonSerializable(typeof(RepostRecord))]
[JsonSerializable(typeof(RepoStrongRef))]
[JsonSerializable(typeof(SearchOption))]
[JsonSerializable(typeof(SearchResults))]
[JsonSerializable(typeof(ServerLinkProperties))]
[JsonSerializable(typeof(SkeletonFeedPost))]
[JsonSerializable(typeof(SkeletonReasonRepost))]
[JsonSerializable(typeof(Session))]
[JsonSerializable(typeof(SessionInfo))]
[JsonSerializable(typeof(Subject))]
[JsonSerializable(typeof(SubscribeRepoMessage))]
[JsonSerializable(typeof(SuggestionsRecord))]
[JsonSerializable(typeof(Success))]
[JsonSerializable(typeof(ThreadPostViewFeed))]
[JsonSerializable(typeof(ThreadView))]
[JsonSerializable(typeof(ThreadGate))]
[JsonSerializable(typeof(ThreadGateReason))]
[JsonSerializable(typeof(ThreadGateRecord))]
[JsonSerializable(typeof(Timeline))]
[JsonSerializable(typeof(UnknownEmbed))]
[JsonSerializable(typeof(UnreadCount))]
[JsonSerializable(typeof(UploadBlobResponse))]
[JsonSerializable(typeof(ATLinkRef))]
[JsonSerializable(typeof(Used))]
[JsonSerializable(typeof(Viewer))]
[JsonSerializable(typeof(AdultContentPref))]
[JsonSerializable(typeof(ContentLabelPref))]
[JsonSerializable(typeof(FeedViewPref))]
[JsonSerializable(typeof(SavedFeedsPref))]
[JsonSerializable(typeof(ActorPreferences))]
[JsonSerializable(typeof(TagSuggestion))]
[JsonSerializable(typeof(TagSuggestions))]
[JsonSerializable(typeof(MessageView))]
[JsonSerializable(typeof(ChatSender))]
[JsonSerializable(typeof(CreateMessage))]
[JsonSerializable(typeof(CreateMessageMessage))]
[JsonSerializable(typeof(ConversationMessages))]
[JsonSerializable(typeof(Conversation))]
[JsonSerializable(typeof(ConversationView))]
[JsonSerializable(typeof(ConversationList))]
[JsonSerializable(typeof(UpdateRead))]
[JsonSerializable(typeof(LogCreateMessage))]
[JsonSerializable(typeof(LogDeleteMessage))]
[JsonSerializable(typeof(LogResponse))]
[JsonSerializable(typeof(LeaveConvoResponse))]
[JsonSerializable(typeof(LogLeaveConvo))]
[JsonSerializable(typeof(LogBeginConvo))]
[JsonSerializable(typeof(DeletedMessageView))]
[JsonSerializable(typeof(UnknownRecord))]
[JsonSerializable(typeof(UnknownRecordResponse))]
[JsonSerializable(typeof(VideoEmbed))]
[JsonSerializable(typeof(AspectRatio))]
[JsonSerializable(typeof(VideoRef))]
[JsonSerializable(typeof(Caption))]
[JsonSerializable(typeof(CaptionBlob))]
[JsonSerializable(typeof(CaptionRef))]
[JsonSerializable(typeof(Video))]
[JsonSerializable(typeof(VideoViewEmbed))]
[JsonSerializable(typeof(AuthSession))]
[JsonSerializable(typeof(AuthorizeState))]
[JsonSerializable(typeof(Dictionary<string, JsonElement>))]
[JsonSerializable(typeof(OidcClientOptions))]
[JsonSerializable(typeof(DPoPProofPayload))]
[JsonSerializable(typeof(ATWebSocketEvent))]
[JsonSerializable(typeof(ATWebSocketCommit))]
[JsonSerializable(typeof(ATWebSocketCommitType))]
[JsonSerializable(typeof(ATWebSocketRecord))]
[JsonSerializable(typeof(ActorRecord))]
[JsonSerializable(typeof(ActorIdentity))]
[JsonSerializable(typeof(PostViewer))]
[JsonSerializable(typeof(PinnedPost))]
[JsonSerializable(typeof(Microsoft.IdentityModel.Tokens.JsonWebKey), TypeInfoPropertyName = nameof(Microsoft.IdentityModel.Tokens.JsonWebKey) + "_A")]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}