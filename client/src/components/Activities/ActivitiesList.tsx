import { Grid } from '@mui/material';
import type { Activity } from '../../types';
import ActivityCard from './ActivityCard';

type Props = {
  activities: Activity[];
  setSelectedActivity: (id: string) => void
}

function ActivitiesList({activities, setSelectedActivity} : Props) {
  
    return (
        <>
        <Grid container spacing={2}>
            {activities.map(a => {
                return (
                <ActivityCard key={a.id} activity={a} setSelectedActivity={setSelectedActivity}/>
                )
            })}
        </Grid>
        </>
    )
}


export default ActivitiesList