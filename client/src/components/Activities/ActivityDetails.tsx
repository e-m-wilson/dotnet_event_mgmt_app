import { Button, Card, CardActions, CardContent, CardMedia, Typography } from '@mui/material';
import { useActivities } from './useActivities';
import { NavLink, useNavigate, useParams } from 'react-router';


function ActivityDetails() {

    const navigate = useNavigate();
    const {id} = useParams();
    const {activity} = useActivities(id);


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
            <Button component={NavLink} to={`/activities/manage/${id}`} color="primary">Edit</Button>
            <Button onClick={() => navigate('/activities')}>Cancel</Button>
        </CardActions>
    </Card>
  )
}

export default ActivityDetails