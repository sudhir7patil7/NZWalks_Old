﻿namespace NZWalks.API.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly AppDbContext appDbContext;

        public WalkRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await appDbContext.Walks.ToListAsync();
        }
    }
}
