import React from 'react'
import { Grid } from '@mui/material';
import ActivitiesList from './ActivitiesList';
import ActivitiesFilter from './ActivitiesFilter';

function ActivityDashboard() {


  return (
    <Grid container spacing={2} sx={{ m : 3 }}>

        <Grid size={8}>
           <ActivitiesList />
        </Grid>

        <Grid size={4}>
            <ActivitiesFilter />
        </Grid>

    </Grid>
  )
}

export default ActivityDashboard