import { useQuery } from "react-query";
import { fetchAbstract } from "../utils/fetchAbstract";

import { urlBuilder } from "../utils/urlBuilder";
import { ExercisesNote } from "../types/ExercisesNote";
import { Exercise } from "../types/Exercise";

export const useExerciseNoteGetAllQuery = (filter: {
  userId?: string;
  createdAt?: string;
  id?: string;
}) => {
  return useQuery({
    queryKey: ["exercises-notes", filter],
    queryFn: async () => {
      const ex = await fetchAbstract(
        urlBuilder("ExercisesNotes/", filter),
        "GET",
      );
      const exx = Array.isArray(ex) ? ex : [ex];

      const exers = await fetchAbstract(urlBuilder("Exercises", filter), "GET");
      const exerss = Array.isArray(exers) ? exers : ([exers] as Exercise[]);

      return exx
        .map((ex) => ({
          ...ex,
          calorie: ex.calories || 0,
          exerciseName:
            exerss.find((exer) => exer.id === ex.exerciseId)?.name || "",
        }))
        .filter((ex) => {
          if (!filter.userId) return true;
          return ex.userId === filter.userId;
        })
        .filter((ex) => {
          if (!filter.createdAt) return true;
          return ex.createdAt === filter.createdAt;
        }) as ExercisesNote[];
    },
  });
};
