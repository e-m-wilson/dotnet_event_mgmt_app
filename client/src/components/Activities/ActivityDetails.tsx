import React from 'react'
import type { Activity } from '../../types'
import { Button, Card, CardActions, CardContent, CardMedia, Typography } from '@mui/material';

type Props = {
    activity: Activity;
    handleCancel: () => void
}

function ActivityDetails({activity, handleCancel} : Props) {
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
            <Typography variant='h4'>{activity.title}</Typography>
            <Typography variant='subtitle1'>ID: {activity.id}</Typography>
            <Typography>City: {activity.city}</Typography>
            <Typography>Venue: {activity.venue}</Typography>
        </CardContent>
        <CardActions>
            <Button color="primary">Edit</Button>
            <Button onClick={() => handleCancel()}>Cancel</Button>
        </CardActions>
    </Card>
  )
}

export default ActivityDetails