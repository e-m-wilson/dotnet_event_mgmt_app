import { Grid, Typography } from '@mui/material';
import ActivityCard from './ActivityCard';
import { useActivities } from './useActivities';

function ActivitiesList() {

    const {activities} = useActivities();

    if(!activities) return <Typography>Activities loading...</Typography>
  
    return (
        <>
        <Grid container spacing={2}>
            {activities.map(a => {
                return (
                <ActivityCard key={a.id} activity={a}/>
                )
            })}
        </Grid>
        </>
    )
}


export default ActivitiesList