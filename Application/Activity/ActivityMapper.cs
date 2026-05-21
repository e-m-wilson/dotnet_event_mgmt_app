// using System;
// using Domain;
// namespace Application;

// public class ActivityMapper : IActivityMapper
// {
//     public ReadActivityDto ToDto(Activity activity)
//     {
//         if (activity == null) return null;

//         return new ReadActivityDto
//         {
//           Id = activity.Id,
//           Title = activity.Title,
//           Category = activity.Category  
//         };
//     }

//     public Activity ToEntity(CreateActivityDto dto)
//     {
//         return new Activity
//         {
//             Title = dto.Title,
//             Description = dto.Description,
//             Category = dto.Category,
//             City = dto.City,
//             Venue = dto.Venue
//         };
//     }
// }
