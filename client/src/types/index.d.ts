export interface Activity {

    id: string,
    title: string,
    date: Date,
    description: string,
    category: string,
    isCancelled: boolean,
    city: string,
    venue: string,
    latitude: string,
    longitude: string
}

export interface LoginCreds {
    username: string
    password: string
}

export interface User {
    id: string
    email: string
    displayName: string
    imageUrl?: string
}