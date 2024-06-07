import { useContext } from "react";
import { UserContext } from "../components/Fallback";
import { useCreateEvent } from "./useCreateEvent";

export const useCreateWeightGoalEvent = () => {
  const user = useContext(UserContext);
  const { mutateAsync: createEvent, ...rest } = useCreateEvent();

  const endDate = new Date(
    new Date().getFullYear(),
    new Date().getMonth() + 1,
    0,
  )
    .toISOString()
    .split("T")[0];

  const weightDifference = Math.abs(user.desiredWeight - user.weight);
  const weightAction = weightDifference > 0 ? "gain" : "lose";

  const description = `Weight goal for ${user.name}. You need to ${weightAction} ${weightDifference} kg. for the end of this month.`;

  return {
    mutateAsync: () => {
      return createEvent({
        endDate,
        startDate: endDate,
        description: description,
        summary: "Weight Goal",
      });
    },
    ...rest,
  };
};
