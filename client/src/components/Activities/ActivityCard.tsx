import React from 'react'
import type { Activity } from '../../types'
import { Button, Card, CardActions, CardContent, Chip, Typography } from '@mui/material';
import { useActivities } from './useActivities';
import { useNavigate } from 'react-router';

type Props = {
    activity: Activity;
}

function ActivityCard({activity} : Props) {

    const navigate = useNavigate()
    const {deleteActivity} = useActivities();

  return (
    <Card>
        <CardContent>
            <Typography>{activity.title}</Typography>
            <Typography>{activity.id}</Typography>
        </CardContent>
        <CardActions>
            <Chip label={activity.category} variant='outlined'/>
            <Button onClick={() => navigate(`/activities/${activity.id}`)}>View</Button>
            <Button onClick={() => deleteActivity.mutateAsync(activity.id)} color='error'>Delete</Button>
        </CardActions>
    </Card>
  )
}

export default ActivityCard