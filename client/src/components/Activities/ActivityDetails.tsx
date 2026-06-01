import type { Activity } from '../../types'
import { Button, Card, CardActions, CardContent, CardMedia, Typography } from '@mui/material';
import { useActivities } from './useActivities';

type Props = {
    a: Activity;
    handleCancel: () => void;
    setEditModeOn: () => void;
}

function ActivityDetails({a, handleCancel, setEditModeOn} : Props) {

    const {activity} = useActivities(a.id);


  return (
    <Card>
        {/* <CardMedia
        component='img'
        src={`/images/${activity.category}.png`}
        /> */}

        <CardMedia
        component='img'
        src={`/images/Test.png`}
        />
        <CardContent>
            <Typography variant='h4'>{activity?.title}</Typography>
            <Typography variant='subtitle1'>ID: {activity?.id}</Typography>
            <Typography>City: {activity?.city}</Typography>
            <Typography>Venue: {activity?.venue}</Typography>
        </CardContent>
        <CardActions>
            <Button onClick={() => setEditModeOn()} color="primary">Edit</Button>
            <Button onClick={() => handleCancel()}>Cancel</Button>
        </CardActions>
    </Card>
  )
}

export default ActivityDetails