﻿using Gunetberg.Api.Dto.Common;
using Gunetberg.Api.Dto.Post;
using Gunetberg.Client.Identity;
using Gunetberg.Domain.Common;
using Gunetberg.Domain.Post;

namespace Gunetberg.Api.Converter
{
    public class PostApiConverter
    {
        private readonly IdentityUtil _identityUtil;
        private readonly TagApiConverter _tagApiConverter;
        private readonly UserApiConverter _userApiConverter;       

        public PostApiConverter(TagApiConverter tagApiConverter, UserApiConverter userApiConverter)
        {
            _tagApiConverter = tagApiConverter;
            _userApiConverter = userApiConverter;
        }

        public CreatePostRequest ToCreatePostRequest(CreatePostRequestDto createPostRequestDto, Guid userId)
        {
            return new CreatePostRequest
            {
                Title = createPostRequestDto.Title,
                Language = createPostRequestDto.Language,
                ImageUrl = createPostRequestDto.ImageUrl,
                Content = createPostRequestDto.Content,
                CreatedBy = userId
            };
        }

        public CompletePostDto ToPostDto(CompletePost post)
        {
            return new CompletePostDto
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                ImageUrl = post.ImageUrl,
                Language = post.Language,
                CreatedAt = post.CreatedAt,
                CreatedBy = post.CreatedBy,
                Tags = _tagApiConverter.ToSimpleTagsDto(post.Tags),
                Author = _userApiConverter.ToAuthorDto(post.Author)
            };
        }

        public IEnumerable<SummaryPostDto> ToSummaryPostDto(IEnumerable<SummaryPost> summaryPosts)
        {
            return summaryPosts.Select(x => ToSummaryPostDto(x));
        }

        public SummaryPostDto ToSummaryPostDto(SummaryPost summaryPost)
        {
            return new SummaryPostDto
            {
                Id = summaryPost.Id,
                Title = summaryPost.Title,
                Summary = summaryPost.Summary,
                ImageUrl = summaryPost.ImageUrl,
                Language = summaryPost.Language,
                Tags = summaryPost.Tags.Select(x => _tagApiConverter.ToSimpleTagDto(x))
            };
        }

        public PostFilterSortField ToPostFilterSortField(string sortFieldDto)
        {
            if (Enum.TryParse<PostFilterSortField>(sortFieldDto, out var result))
            {
                return result;
            }

            return PostFilterSortField.CreatedAt;
        }

        public SearchRequest<PostFilterRequest, PostFilterSortField> ToSearchPostRequest(SearchRequestDto<PostFilterRequestDto> searchPostRequestDto)
        {
            return new SearchRequest<PostFilterRequest, PostFilterSortField>
            {
                Page = searchPostRequestDto?.Page,
                ItemsPerPage = searchPostRequestDto?.ItemsPerPage,
                SortField = ToPostFilterSortField(searchPostRequestDto?.SortField),
                SortByDescending = searchPostRequestDto.SortByDescending,
                FilterRequest = new PostFilterRequest
                {
                    FilterByTitle = searchPostRequestDto?.Filter?.FilterByTitle,
                    FilterByTags = searchPostRequestDto?.Filter.FilterByTags
                }

            };
        }


        public SearchResultDto<SummaryPostDto> ToSearchPostResultDto(SearchResult<SummaryPost> searchResult)
        {
            return new SearchResultDto<SummaryPostDto>
            {
                Page = searchResult.Page,
                Pages = searchResult.Pages,
                ItemsPerPage = searchResult.ItemsPerPage,
                SortByDescending = searchResult.SortByDescending,
                SortingField = searchResult.SortingField,
                Items = ToSummaryPostDto(searchResult.Items)
            };
        }

        public UpdatePostRequest ToUpdatePostRequest(Guid id, Guid userId, UpdatePostRequestDto updatePostApiRequestDto)
        {
            return new UpdatePostRequest
            {
                Id = id,
                Title = updatePostApiRequestDto.Title,
                Language = updatePostApiRequestDto.Language,
                CreatedBy = userId,
                ImageUrl = updatePostApiRequestDto.ImageUrl,
                Content = updatePostApiRequestDto.Content,
                Tags = updatePostApiRequestDto.Tags
            };
        }
    }
}